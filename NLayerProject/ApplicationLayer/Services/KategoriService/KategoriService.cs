using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Models.ViewModels;
using AutoMapper;
using DomainLayer.Entities.Concrete;
using DomainLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.KategoriService
{
    public class KategoriService : IKategoriService //Generate ctor işlemi yap
    {
        //Daha Sonra eksik olanları ekle 

        private readonly IKategorıRepostory _kategorıRepostory;
        private readonly IMapper _mapper;

        public KategoriService(IKategorıRepostory kategorıRepostory, IMapper mapper)
        {
            _kategorıRepostory = kategorıRepostory;
            _mapper = mapper;
        }

        public async Task<List<KategoriDTO>> TümKategorilerAsync()
        {
            var kategoriler = await _kategorıRepostory.TumAktifleriListeleAsync();
            List<KategoriDTO> _kategoriler = new List<KategoriDTO>();

            _mapper.Map(kategoriler, _kategoriler);
            return _kategoriler;

        }

        public async Task <KategoriVM> KategoriBulAsync(int id)
        {
            Kategorı kategori = await _kategorıRepostory.AraAsync(id);
            KategoriVM kategoriDetay = new KategoriVM();
            _mapper.Map(kategori, kategoriDetay);
            return kategoriDetay;
        }

        public async Task KategoriEkleAsync(KategoriEkleDTO kategoriEkleDTO)
        {
            Kategorı kategorı = new Kategorı();
            _mapper.Map(kategoriEkleDTO,kategorı);
            await _kategorıRepostory.EkleAsync(kategorı);

        }
        public async Task<bool> KategoriGüncelleAsync(KategoriGuncelleDTO kategoriGuncelleDTO)
        {
            Kategorı kategorı = new Kategorı();
            _mapper.Map(kategoriGuncelleDTO, kategorı);

            return await _kategorıRepostory.GüncelleAsync(kategorı);

        }

       public async Task<bool> KategoriSil(int id )
        {
            return await _kategorıRepostory.SilAsync(id);
        }

       

        public async Task<IEnumerable<KategoriVM>> KategoriListeleAsync()
        {
            List<Kategorı> kategoriler = _kategorıRepostory.TumAktifleriListeleAsync().Result.ToList();
            List<KategoriVM> kategoriVM = new List<KategoriVM>();
            _mapper.Map(kategoriVM,kategoriler);

            return kategoriVM;
        }

        public Task KategoriGüncelleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<KategoriGuncelleDTO> IKategoriService.KategoriGüncelleAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}