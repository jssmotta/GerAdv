// GridsDesktop.tsx - Versão Refatorada
'use client';
import React from 'react';
import {
  Grid, 
  GridColumn, 
} from '@progress/kendo-react-grid';
import { useSystemContext } from '@/app/context/SystemContext';
import { IFuncao } from '../../Interfaces/interface.Funcao';
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
interface FuncaoGridProps {
  data: IFuncao[];
  onRowClick: (funcao: IFuncao) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const FuncaoGridDesktopComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: FuncaoGridProps) => {
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
const filterLogic = useCallback((data: IFuncao, filters: Record<string, any>) => {
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

const openConsultaFuncionarios = (id: number) => {
  router.push(`/pages/funcionarios/?funcao=${id}`);
};
const EditarCellFuncionarios = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaFuncionarios(props.dataItem.id)}><span title='Editar Colaborador'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaPrepostos = (id: number) => {
  router.push(`/pages/prepostos/?funcao=${id}`);
};
const EditarCellPrepostos = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaPrepostos(props.dataItem.id)}><span title='Editar Prepostos'><SvgIcon icon={pencilIcon} /></span></div>
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
  title='Colaborador'
  cells={{ data: EditarCellFuncionarios }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Prepostos'
  cells={{ data: EditarCellPrepostos }}
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
  tableName: 'funcao'
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
  className='grid-desktop-funcao'
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