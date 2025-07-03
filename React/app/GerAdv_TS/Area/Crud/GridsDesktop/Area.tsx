// GridsDesktop.tsx - Versão Refatorada
'use client';
import React from 'react';
import {
  Grid, 
  GridColumn, 
} from '@progress/kendo-react-grid';
import { useSystemContext } from '@/app/context/SystemContext';
import { IArea } from '../../Interfaces/interface.Area';
import { useRouter } from 'next/navigation';
import { useMemo, useCallback } from 'react';
import { applyFilter, CRUD_CONSTANTS } from '@/app/tools/crud';
import { SvgIcon } from '@progress/kendo-react-common';
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';
import { useHiddenColumns } from '@/app/hooks/useHiddenColumns';
import { GridColumnMenu } from '@/app/components/Cruds/GridColumnMenu';
import { useGridFilter } from '@/app/hooks/useGridFilter';
import { useGridSort } from '@/app/hooks/useGridSort';
import { useGridPagination } from '@/app/hooks/useGridPagination';
interface AreaGridProps {
  data: IArea[];
  onRowClick: (area: IArea) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const AreaGridDesktopComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: AreaGridProps) => {
const router = useRouter();
const { systemContext } = useSystemContext();
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
const filterLogic = useCallback((data: IArea, filters: Record<string, any>) => {
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

const openConsultaAcao = (id: number) => {
  router.push(`/pages/acao/?area=${id}`);
};
const EditarCellAcao = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaAcao(props.dataItem.id)}><span title='Editar Acao'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaAgenda = (id: number) => {
  router.push(`/pages/agenda/?area=${id}`);
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
  router.push(`/pages/agendafinanceiro/?area=${id}`);
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
const openConsultaAreasJustica = (id: number) => {
  router.push(`/pages/areasjustica/?area=${id}`);
};
const EditarCellAreasJustica = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaAreasJustica(props.dataItem.id)}><span title='Editar Areas Justica'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaDivisaoTribunal = (id: number) => {
  router.push(`/pages/divisaotribunal/?area=${id}`);
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
const openConsultaFase = (id: number) => {
  router.push(`/pages/fase/?area=${id}`);
};
const EditarCellFase = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaFase(props.dataItem.id)}><span title='Editar Fase'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaObjetos = (id: number) => {
  router.push(`/pages/objetos/?area=${id}`);
};
const EditarCellObjetos = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaObjetos(props.dataItem.id)}><span title='Editar Objetos'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaPoderJudiciarioAssociado = (id: number) => {
  router.push(`/pages/poderjudiciarioassociado/?area=${id}`);
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
const openConsultaProcessos = (id: number) => {
  router.push(`/pages/processos/?area=${id}`);
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
const openConsultaTipoRecurso = (id: number) => {
  router.push(`/pages/tiporecurso/?area=${id}`);
};
const EditarCellTipoRecurso = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaTipoRecurso(props.dataItem.id)}><span title='Editar Tipo Recurso'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaTribunal = (id: number) => {
  router.push(`/pages/tribunal/?area=${id}`);
};
const EditarCellTribunal = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaTribunal(props.dataItem.id)}><span title='Editar Tribunal'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};

const ExcluirLinha = (e: any) => {
  return (
  <td>
    <span onClick={() => onDeleteClick(e) } title='Excluit item' ><SvgIcon icon={trashIcon} /></span>
  </td>
);
};
const gridColumns = useMemo(() => [
  <GridColumn field='index' title='#' sortable={false} filterable={false} width='55px' cells={{ data: RowNumberCell }} />,
  <GridColumn field='descricao' title='Descricao' sortable={true} filterable={true} />, /* Track G.02 */
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Acao'
  cells={{ data: EditarCellAcao }}
  />, 
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
  title='Areas Justica'
  cells={{ data: EditarCellAreasJustica }}
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
  title='Fase'
  cells={{ data: EditarCellFase }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Objetos'
  cells={{ data: EditarCellObjetos }}
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
  title='Processos'
  cells={{ data: EditarCellProcessos }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Tipo Recurso'
  cells={{ data: EditarCellTipoRecurso }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Tribunal'
  cells={{ data: EditarCellTribunal }}
  />, 
  <GridColumn
  field='id'
  width={'55px'}
  title='Excluir'
  sortable={false} filterable={false}
  cells={{ data: ExcluirLinha }} />
  ], []);
  // Hook customizado para gerenciar colunas ocultas
  const {
    columnsState, 
    syncedGridColumns, 
    initialized, 
    handleColumnsStateChange
  } = useHiddenColumns({
  gridColumns, 
  systemContextId: systemContext?.Id, 
  tableName: 'area'
});
// Componente do menu de colunas
const columnMenuComponent = GridColumnMenu({
  columnsState, 
  onColumnsStateChange: handleColumnsStateChange
});
return (
<>
{initialized && (
  <Grid
  columnMenu={columnMenuComponent}
  columnsState={columnsState}
  className='grid-desktop-area'
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
  onRowDoubleClick={(e) => handleRowClick(e)}>
  {syncedGridColumns}
</Grid>
)}
</>
);
}
);