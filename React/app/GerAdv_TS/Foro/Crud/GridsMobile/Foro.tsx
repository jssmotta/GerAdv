// GridsMobile.tsx
'use client';
import React from 'react';
import { Grid, GridColumn } from '@progress/kendo-react-grid';
import { IForo } from '../../Interfaces/interface.Foro';
import { useRouter } from 'next/navigation';
import { useMemo, useCallback } from 'react';
import { applyFilter, CRUD_CONSTANTS } from '@/app/tools/crud';
import { SvgIcon } from '@progress/kendo-react-common';
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';
import { useGridFilter } from '@/app/hooks/useGridFilter';
import { useGridSort } from '@/app/hooks/useGridSort';
import { useGridPagination } from '@/app/hooks/useGridPagination';
interface ForoGridProps {
  data: IForo[];
  onRowClick: (foro: IForo) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const ForoGridMobileComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: ForoGridProps) => {
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
const filterLogic = useCallback((data: IForo, filters: Record<string, any>) => {
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

const openConsultaAgendaRecords = (id: number) => {
  router.push(`/pages/agendarecords/?foro=${id}`);
};
const EditarCellAgendaRecords = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaAgendaRecords(props.dataItem.id)}><span title='Editar Agenda Records'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaDivisaoTribunal = (id: number) => {
  router.push(`/pages/divisaotribunal/?foro=${id}`);
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
const openConsultaInstancia = (id: number) => {
  router.push(`/pages/instancia/?foro=${id}`);
};
const EditarCellInstancia = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaInstancia(props.dataItem.id)}><span title='Editar Instancia'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaPoderJudiciarioAssociado = (id: number) => {
  router.push(`/pages/poderjudiciarioassociado/?foro=${id}`);
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
const gridColumns = useMemo(() => [
  <GridColumn field='index' title='#' sortable={false} filterable={false} width='55px' cells={{ data: RowNumberCell }} />,
  <GridColumn field='nome' title='Nome' />,
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Agenda Records'
  cells={{ data: EditarCellAgendaRecords }}
  />, 
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
  title='Instancia'
  cells={{ data: EditarCellInstancia }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Poder Judiciario Associado'
  cells={{ data: EditarCellPoderJudiciarioAssociado }}
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
className='grid-mobile-foro'
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