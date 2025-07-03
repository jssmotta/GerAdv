// GridsMobile.tsx
'use client';
import React from 'react';
import { Grid, GridColumn } from '@progress/kendo-react-grid';
import { IAdvogados } from '../../Interfaces/interface.Advogados';
import { useRouter } from 'next/navigation';
import { useMemo, useCallback } from 'react';
import { applyFilter, CRUD_CONSTANTS } from '@/app/tools/crud';
import { SvgIcon } from '@progress/kendo-react-common';
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';
import { useGridFilter } from '@/app/hooks/useGridFilter';
import { useGridSort } from '@/app/hooks/useGridSort';
import { useGridPagination } from '@/app/hooks/useGridPagination';
interface AdvogadosGridProps {
  data: IAdvogados[];
  onRowClick: (advogados: IAdvogados) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const AdvogadosGridMobileComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: AdvogadosGridProps) => {
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
const filterLogic = useCallback((data: IAdvogados, filters: Record<string, any>) => {
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

const openConsultaAgenda = (id: number) => {
  router.push(`/pages/agenda/?advogados=${id}`);
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
  router.push(`/pages/agendafinanceiro/?advogados=${id}`);
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
const openConsultaAgendaQuem = (id: number) => {
  router.push(`/pages/agendaquem/?advogados=${id}`);
};
const EditarCellAgendaQuem = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaAgendaQuem(props.dataItem.id)}><span title='Editar Agenda Quem'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaAgendaRepetir = (id: number) => {
  router.push(`/pages/agendarepetir/?advogados=${id}`);
};
const EditarCellAgendaRepetir = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaAgendaRepetir(props.dataItem.id)}><span title='Editar Agenda Repetir'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaContratos = (id: number) => {
  router.push(`/pages/contratos/?advogados=${id}`);
};
const EditarCellContratos = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaContratos(props.dataItem.id)}><span title='Editar Contratos'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaHorasTrab = (id: number) => {
  router.push(`/pages/horastrab/?advogados=${id}`);
};
const EditarCellHorasTrab = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaHorasTrab(props.dataItem.id)}><span title='Editar Horas Trab'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaParceriaProc = (id: number) => {
  router.push(`/pages/parceriaproc/?advogados=${id}`);
};
const EditarCellParceriaProc = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaParceriaProc(props.dataItem.id)}><span title='Editar Parceria Proc'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaProcessos = (id: number) => {
  router.push(`/pages/processos/?advogados=${id}`);
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
const openConsultaProProcuradores = (id: number) => {
  router.push(`/pages/proprocuradores/?advogados=${id}`);
};
const EditarCellProProcuradores = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaProProcuradores(props.dataItem.id)}><span title='Editar Pro Procuradores'><SvgIcon icon={pencilIcon} /></span></div>
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
  title='Agenda Quem'
  cells={{ data: EditarCellAgendaQuem }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Agenda Repetir'
  cells={{ data: EditarCellAgendaRepetir }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Contratos'
  cells={{ data: EditarCellContratos }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Horas Trab'
  cells={{ data: EditarCellHorasTrab }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Parceria Proc'
  cells={{ data: EditarCellParceriaProc }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Processos'
  cells={{ data: EditarCellProcessos }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Pro Procuradores'
  cells={{ data: EditarCellProProcuradores }}
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
className='grid-mobile-advogados'
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