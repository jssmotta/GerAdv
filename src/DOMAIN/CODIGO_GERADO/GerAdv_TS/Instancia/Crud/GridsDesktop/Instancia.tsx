// GridsDesktop.tsx - Versão Refatorada
'use client';
import React from 'react';
import {
  Grid, 
  GridColumn, 
} from '@progress/kendo-react-grid';
import { useSystemContext } from '@/app/context/SystemContext';
import { IInstancia } from '../../Interfaces/interface.Instancia';
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
interface InstanciaGridProps {
  data: IInstancia[];
  onRowClick: (instancia: IInstancia) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const InstanciaGridDesktopComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: InstanciaGridProps) => {
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
  nroprocesso: '',
};
// Lógica de filtro customizada usando useCallback
const filterLogic = useCallback((data: IInstancia, filters: Record<string, any>) => {
  const nroprocessoMatches = applyFilter(data, 'nroprocesso', filters.nroprocesso);
  return nroprocessoMatches
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

const openConsultaNENotas = (id: number) => {
  router.push(`/pages/nenotas/?instancia=${id}`);
};
const EditarCellNENotas = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaNENotas(props.dataItem.id)}><span title='Editar N E Notas'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaProSucumbencia = (id: number) => {
  router.push(`/pages/prosucumbencia/?instancia=${id}`);
};
const EditarCellProSucumbencia = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaProSucumbencia(props.dataItem.id)}><span title='Editar Pro Sucumbencia'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaTribunal = (id: number) => {
  router.push(`/pages/tribunal/?instancia=${id}`);
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
  <GridColumn field='nroprocesso' title='NroProcesso' sortable={true} filterable={true} />, /* Track G.02 */
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='N E Notas'
  cells={{ data: EditarCellNENotas }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Pro Sucumbencia'
  cells={{ data: EditarCellProSucumbencia }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Tribunal'
  cells={{ data: EditarCellTribunal }}
  />, 
  <GridColumn field='nropastaprocessos' title='Processos' sortable={false} filterable={false} />, /* Track G.01 */

  <GridColumn field='descricaoacao' title='Acao' sortable={false} filterable={false} />, /* Track G.01 */

  <GridColumn field='nomeforo' title='Foro' sortable={false} filterable={false} />, /* Track G.01 */

  <GridColumn field='descricaotiporecurso' title='Tipo Recurso' sortable={false} filterable={false} />, /* Track G.01 */
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
  tableName: 'instancia'
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
  className='grid-desktop-instancia'
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