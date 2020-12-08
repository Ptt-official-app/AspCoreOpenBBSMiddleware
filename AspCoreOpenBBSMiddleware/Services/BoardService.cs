using AspCoreOpenBBSMiddleware.DTO;
using Infrastructure.Repository;
using System.Linq;

namespace AspCoreOpenBBSMiddleware.Services
{
    public class BoardService
    {
        private readonly BoardRepository _boardRepository;

        public BoardService(BoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public BoardListResult Get(int page, int count)
        {
            var list = _boardRepository.Get()
                                        .Skip((page - 1) * count)
                                        .Take(count)
                                        .ToDTO();
            if (!list.Any()) return null;

            var next = _boardRepository.Get()
                                        .Skip(page * count)
                                        .Take(1)
                                        .SingleOrDefault()
                                        .ToDTO();
            return new BoardListResult
            {
                List = list.AsEnumerable(),
                Next = next
                //NextBoardID = next?.BoardId
            };
        }
    }
}
