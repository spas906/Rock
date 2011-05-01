//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the T4\Model.tt template.
//
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Rock.Models.Cms;
using Rock.Repository.Cms;

namespace Rock.Services.Cms
{
    public partial class BlockInstanceService : Rock.Services.Service
    {
        private IBlockInstanceRepository _repository;

        public BlockInstanceService()
			: this( new EntityBlockInstanceRepository() )
        { }

        public BlockInstanceService( IBlockInstanceRepository BlockInstanceRepository )
        {
            _repository = BlockInstanceRepository;
        }

        public IQueryable<Rock.Models.Cms.BlockInstance> Queryable()
        {
            return _repository.AsQueryable();
        }

        public Rock.Models.Cms.BlockInstance GetBlockInstance( int id )
        {
            return _repository.FirstOrDefault( t => t.Id == id );
        }
		
        public IEnumerable<Rock.Models.Cms.BlockInstance> GetBlockInstancesByLayout( string layout )
        {
            return _repository.Find( t => t.Layout == layout );
        }
		
        public IEnumerable<Rock.Models.Cms.BlockInstance> GetBlockInstancesByPageId( int? pageId )
        {
            return _repository.Find( t => t.PageId == pageId );
        }
		
        public void AddBlockInstance( Rock.Models.Cms.BlockInstance BlockInstance )
        {
            if ( BlockInstance.Guid == Guid.Empty )
                BlockInstance.Guid = Guid.NewGuid();

            _repository.Add( BlockInstance );
        }

        public void AttachBlockInstance( Rock.Models.Cms.BlockInstance BlockInstance )
        {
            _repository.Attach( BlockInstance );
        }

		public void DeleteBlockInstance( Rock.Models.Cms.BlockInstance BlockInstance )
        {
            _repository.Delete( BlockInstance );
        }

        public void Save( Rock.Models.Cms.BlockInstance BlockInstance, int? personId )
        {
            List<Rock.Models.Core.EntityChange> entityChanges = _repository.Save( BlockInstance, personId );

			if ( entityChanges != null )
            {
                Rock.Services.Core.EntityChangeService entityChangeService = new Rock.Services.Core.EntityChangeService();

                foreach ( Rock.Models.Core.EntityChange entityChange in entityChanges )
                {
                    entityChange.EntityId = BlockInstance.Id;
                    entityChangeService.AddEntityChange ( entityChange );
                    entityChangeService.Save( entityChange, personId );
                }
            }
        }
    }
}
