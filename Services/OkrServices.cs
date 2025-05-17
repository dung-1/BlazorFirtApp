using BlazorApp1.Data.Models;
using Supabase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    public class OkrServices
    {
        private readonly Client _client;

        public OkrServices(Client client)
        {
            _client = client;
        }

        /// <summary>
        /// Lấy tất cả OKRs từ Supabase
        /// </summary>
        public async Task<List<Taget>> GetAllOkrsAsync()
        {
            var result = await _client.From<Taget>().Get();
            return result.Models;
        }

        /// <summary>
        /// Thêm một OKR mới vào Supabase
        /// </summary>
        /// <param name="okr">Đối tượng OKR cần thêm</param>
        /// <returns>OKR đã được thêm (bao gồm ID được tạo)</returns>
        public async Task<Taget> AddOkrAsync(Taget okr)
        {
            // Đảm bảo các trường bắt buộc không bị null
            okr.Objective = okr.Objective ?? string.Empty;
            okr.Assignee = okr.Assignee ?? string.Empty;
            okr.ProgressStatus = okr.ProgressStatus ?? string.Empty;
            okr.Change = okr.Change ?? string.Empty;
            okr.Checkin = okr.Checkin ?? string.Empty;
            okr.Status = okr.Status ?? string.Empty;

            var response = await _client.From<Taget>().Insert(okr);
            if (response.Models == null || response.Models.Count == 0)
            {
                throw new Exception("Failed to add OKR to Supabase.");
            }

            // Trả về OKR đã được thêm với ID được tạo bởi Supabase
            return response.Models[0];
        }

        /// <summary>
        /// Cập nhật một OKR hiện có trong Supabase
        /// </summary>
        /// <param name="okr">Đối tượng OKR cần cập nhật</param>
        /// <returns>OKR đã được cập nhật</returns>
        public async Task<Taget> UpdateOkrAsync(Taget okr)
        {
            // Đảm bảo các trường bắt buộc không bị null
            okr.Objective = okr.Objective ?? string.Empty;
            okr.Assignee = okr.Assignee ?? string.Empty;
            okr.ProgressStatus = okr.ProgressStatus ?? string.Empty;
            okr.Change = okr.Change ?? string.Empty;
            okr.Checkin = okr.Checkin ?? string.Empty;
            okr.Status = okr.Status ?? string.Empty;

            var response = await _client.From<Taget>()
                .Where(x => x.Id == okr.Id)
                .Update(okr);

            if (response.Models == null || response.Models.Count == 0)
            {
                throw new Exception($"Failed to update OKR with ID {okr.Id}.");
            }

            // Trả về OKR đã được cập nhật
            return response.Models[0];
        }

        /// <summary>
        /// Xóa một OKR khỏi Supabase
        /// </summary>
        /// <param name="id">ID của OKR cần xóa</param>
        //public async Task DeleteOkrAsync(long id)
        //{
        //    var response = await _client.From<Taget>()
        //        .Where(x => x.Id == id)
        //        .Delete();

        //    if (response.Models == null || response.Models.Count == 0)
        //    {
        //        throw new Exception($"Failed to delete OKR with ID {id}.");
        //    }
        //}

        /// <summary>
        /// Lấy một OKR theo ID
        /// </summary>
        /// <param name="id">ID của OKR cần lấy</param>
        /// <returns>Đối tượng OKR nếu tìm thấy, null nếu không tìm thấy</returns>
        public async Task<Taget> GetOkrByIdAsync(long id)
        {
            var response = await _client.From<Taget>()
                .Where(x => x.Id == id)
                .Get();

            if (response.Models == null || response.Models.Count == 0)
            {
                return null;
            }

            return response.Models[0];
        }
    }
}
