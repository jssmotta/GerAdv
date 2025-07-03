// GridsMobile.tsx
'use client';
import React from 'react';
import { Grid, GridColumn } from '@progress/kendo-react-grid';
import { IOponentes } from '../../Interfaces/interface.Oponentes';
import { useRouter } from 'next/navigation';
import { useMemo, useCallback } from 'react';
import { applyFilter, CRUD_CONSTANTS } from '@/app/tools/crud';
import { SvgIcon } from '@progress/kendo-react-common';
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';
import { useGridFilter } from '@/app/hooks/useGridFilter';
import { useGridSort } from '@/app/hooks/useGridSort';
import { useGridPagination } from '@/app/hooks/useGridPagination';
interface OponentesGridProps {
  data: IOponentes[];
  onRowClick: (oponentes: IOponentes) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const OponentesGridMobileComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: OponentesGridProps) => {
const router = useRouter();

const RowNumberCell = (props: any) => <td>{props.dataIndex + 1}</td>;
// Hook para paginação
const { page, handlePageChange } = useGridPagination({
  initialSkip: 0, 
  initialTake: 10, 
});
// Configuração dos filtros iniciais
const initialFilters = {
  nome: '',
};
// Lógica de filtro customizada usando useCallback
const filterLogic = useCallback((data: IOponentes, filters: Record<string, any>) => {
  const nomeMatches = applyFilter(data, 'nome', filters.nome);
  return nomeMatches
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

const openConsultaGruposEmpresas = (id: number) => {
  router.push(`/pages/gruposempresas/?oponentes=${id}`);
};
const EditarCellGruposEmpresas = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaGruposEmpresas(props.dataItem.id)}><span title='Editar Grupos Empresas'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaOponentesRepLegal = (id: number) => {
  router.push(`/pages/oponentesreplegal/?oponentes=${id}`);
};
const EditarCellOponentesRepLegal = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaOponentesRepLegal(props.dataItem.id)}><span title='Editar Oponentes Rep Legal'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaProcessos = (id: number) => {
  router.push(`/pages/processos/?oponentes=${id}`);
};
const EditarCellProcessos = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaProcessos(props.dataItem.id)}><span title='Editar Processos'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const gridColumns = useMemo(() => [
  <GridColumn field='index' title='#' sortable={false} filterable={false} width='55px' cells={{ data: RowNumberCell }} />,
  <GridColumn field='nome' title='Nome' />,
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Grupos Empresas'
  cells={{ data: EditarCellGruposEmpresas }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Oponentes Rep Legal'
  cells={{ data: EditarCellOponentesRepLegal }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Processos'
  cells={{ data: EditarCellProcessos }}
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
className='grid-mobile-oponentes'
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