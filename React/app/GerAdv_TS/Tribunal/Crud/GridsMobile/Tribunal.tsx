// GridsMobile.tsx
'use client';
import React from 'react';
import { Grid, GridColumn } from '@progress/kendo-react-grid';
import { ITribunal } from '../../Interfaces/interface.Tribunal';
import { useRouter } from 'next/navigation';
import { useMemo, useCallback } from 'react';
import { applyFilter, CRUD_CONSTANTS } from '@/app/tools/crud';
import { SvgIcon } from '@progress/kendo-react-common';
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';
import { useGridFilter } from '@/app/hooks/useGridFilter';
import { useGridSort } from '@/app/hooks/useGridSort';
import { useGridPagination } from '@/app/hooks/useGridPagination';
interface TribunalGridProps {
  data: ITribunal[];
  onRowClick: (tribunal: ITribunal) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const TribunalGridMobileComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: TribunalGridProps) => {
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
const filterLogic = useCallback((data: ITribunal, filters: Record<string, any>) => {
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

const openConsultaDivisaoTribunal = (id: number) => {
  router.push(`/pages/divisaotribunal/?tribunal=${id}`);
};
const EditarCellDivisaoTribunal = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaDivisaoTribunal(props.dataItem.id)}><span title='Editar Divisao Tribunal'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaPoderJudiciarioAssociado = (id: number) => {
  router.push(`/pages/poderjudiciarioassociado/?tribunal=${id}`);
};
const EditarCellPoderJudiciarioAssociado = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaPoderJudiciarioAssociado(props.dataItem.id)}><span title='Editar Poder Judiciario Associado'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaTribEnderecos = (id: number) => {
  router.push(`/pages/tribenderecos/?tribunal=${id}`);
};
const EditarCellTribEnderecos = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaTribEnderecos(props.dataItem.id)}><span title='Editar Trib Endereços'><SvgIcon icon={pencilIcon} /></span></div>
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
  title='Divisao Tribunal'
  cells={{ data: EditarCellDivisaoTribunal }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Poder Judiciario Associado'
  cells={{ data: EditarCellPoderJudiciarioAssociado }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Trib Endereços'
  cells={{ data: EditarCellTribEnderecos }}
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
className='grid-mobile-tribunal'
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