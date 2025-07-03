// GridsMobile.tsx
'use client';
import React from 'react';
import { Grid, GridColumn } from '@progress/kendo-react-grid';
import { IGruposEmpresas } from '../../Interfaces/interface.GruposEmpresas';
import { useRouter } from 'next/navigation';
import { useMemo, useCallback } from 'react';
import { applyFilter, CRUD_CONSTANTS } from '@/app/tools/crud';
import { SvgIcon } from '@progress/kendo-react-common';
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';
import { useGridFilter } from '@/app/hooks/useGridFilter';
import { useGridSort } from '@/app/hooks/useGridSort';
import { useGridPagination } from '@/app/hooks/useGridPagination';
interface GruposEmpresasGridProps {
  data: IGruposEmpresas[];
  onRowClick: (gruposempresas: IGruposEmpresas) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const GruposEmpresasGridMobileComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: GruposEmpresasGridProps) => {
const router = useRouter();

const RowNumberCell = (props: any) => <td>{props.dataIndex + 1}</td>;
// Hook para paginação
const { page, handlePageChange } = useGridPagination({
  initialSkip: 0, 
  initialTake: 10, 
});
// Configuração dos filtros iniciais
const initialFilters = {
  descricao: '',
};
// Lógica de filtro customizada usando useCallback
const filterLogic = useCallback((data: IGruposEmpresas, filters: Record<string, any>) => {
  const descricaoMatches = applyFilter(data, 'descricao', filters.descricao);
  return descricaoMatches
  ;
}, []);
// Hook para filtros
const { columnFilters, filteredData, handleFilterChange } = useGridFilter({
  data, 
  initialFilters, 
  filterLogic, 
});
// Hook para ordenação
const { sort, sortedData, handleSortChange } = useGridSort({
  data: filteredData, 
});
const handleRowClick = (e: any) => {
  onRowClick(e.dataItem);
};

const openConsultaGruposEmpresasCli = (id: number) => {
  router.push(`/pages/gruposempresascli/?gruposempresas=${id}`);
};
const EditarCellGruposEmpresasCli = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaGruposEmpresasCli(props.dataItem.id)}><span title='Editar Grupos Empresas Cli'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const gridColumns = useMemo(() => [
  <GridColumn field='index' title='#' sortable={false} filterable={false} width='55px' cells={{ data: RowNumberCell }} />,
  <GridColumn field='descricao' title='Descricao' />,
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Grupos Empresas Cli'
  cells={{ data: EditarCellGruposEmpresasCli }}
  />, 
  ], []);
  const ExcluirLinha = (e: any) => {
    return (
    <td>
      <span onClick={() => onDeleteClick(e) } title='Excluit item' ><SvgIcon icon={trashIcon} /></span>
    </td>
  );
};
return (
<>
<Grid
className='grid-mobile-gruposempresas'
data={sortedData.slice(page.skip, page.skip + page.take)}
skip={page.skip}
take={page.take}
total={sortedData.length}
pageable={{
  pageSizes: Array.from(CRUD_CONSTANTS.PAGINATION.PAGE_SIZES), 
  buttonCount: CRUD_CONSTANTS.PAGINATION.BUTTON_COUNT, 
}}
onPageChange={handlePageChange}
sortable={true}
sort={sort}
onSortChange={handleSortChange}
resizable={true}
reorderable={true}
filterable={true}
onFilterChange={handleFilterChange}
onRowClick={(e) => handleRowClick(e)}>
{gridColumns}
</Grid>
</>
);
}
);