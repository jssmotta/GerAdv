// GridsMobile.tsx
'use client';
import React from 'react';
import { Grid, GridColumn } from '@progress/kendo-react-grid';
import { ITipoCompromisso } from '../../Interfaces/interface.TipoCompromisso';
import { useRouter } from 'next/navigation';
import { useMemo, useCallback } from 'react';
import { applyFilter, CRUD_CONSTANTS } from '@/app/tools/crud';
import { SvgIcon } from '@progress/kendo-react-common';
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';
import { useGridFilter } from '@/app/hooks/useGridFilter';
import { useGridSort } from '@/app/hooks/useGridSort';
import { useGridPagination } from '@/app/hooks/useGridPagination';
interface TipoCompromissoGridProps {
  data: ITipoCompromisso[];
  onRowClick: (tipocompromisso: ITipoCompromisso) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const TipoCompromissoGridMobileComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: TipoCompromissoGridProps) => {
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
const filterLogic = useCallback((data: ITipoCompromisso, filters: Record<string, any>) => {
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

const openConsultaAgenda = (id: number) => {
  router.push(`/pages/agenda/?tipocompromisso=${id}`);
};
const EditarCellAgenda = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaAgenda(props.dataItem.id)}><span title='Editar Agenda'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaAgendaFinanceiro = (id: number) => {
  router.push(`/pages/agendafinanceiro/?tipocompromisso=${id}`);
};
const EditarCellAgendaFinanceiro = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaAgendaFinanceiro(props.dataItem.id)}><span title='Editar Agenda Financeiro'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaNECompromissos = (id: number) => {
  router.push(`/pages/necompromissos/?tipocompromisso=${id}`);
};
const EditarCellNECompromissos = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaNECompromissos(props.dataItem.id)}><span title='Editar N E Compromissos'><SvgIcon icon={pencilIcon} /></span></div>
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
  title='Agenda'
  cells={{ data: EditarCellAgenda }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Agenda Financeiro'
  cells={{ data: EditarCellAgendaFinanceiro }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='N E Compromissos'
  cells={{ data: EditarCellNECompromissos }}
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
className='grid-mobile-tipocompromisso'
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