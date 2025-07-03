// GridsDesktop.tsx - Versão Refatorada
'use client';
import React from 'react';
import {
  Grid, 
  GridColumn, 
} from '@progress/kendo-react-grid';
import { useSystemContext } from '@/app/context/SystemContext';
import { IContatoCRM } from '../../Interfaces/interface.ContatoCRM';
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
interface ContatoCRMGridProps {
  data: IContatoCRM[];
  onRowClick: (contatocrm: IContatoCRM) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const ContatoCRMGridDesktopComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: ContatoCRMGridProps) => {
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

};
// Lógica de filtro customizada usando useCallback
const filterLogic = useCallback((data: IContatoCRM, filters: Record<string, any>) => {

  return true;
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

const openConsultaContatoCRMOperador = (id: number) => {
  router.push(`/pages/contatocrmoperador/?contatocrm=${id}`);
};
const EditarCellContatoCRMOperador = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaContatoCRMOperador(props.dataItem.id)}><span title='Editar Contato C R M Operador'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaDocsRecebidosItens = (id: number) => {
  router.push(`/pages/docsrecebidositens/?contatocrm=${id}`);
};
const EditarCellDocsRecebidosItens = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaDocsRecebidosItens(props.dataItem.id)}><span title='Editar Docs Recebidos Itens'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaRecados = (id: number) => {
  router.push(`/pages/recados/?contatocrm=${id}`);
};
const EditarCellRecados = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaRecados(props.dataItem.id)}><span title='Editar Recados'><SvgIcon icon={pencilIcon} /></span></div>
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
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Contato C R M Operador'
  cells={{ data: EditarCellContatoCRMOperador }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Docs Recebidos Itens'
  cells={{ data: EditarCellDocsRecebidosItens }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Recados'
  cells={{ data: EditarCellRecados }}
  />, 
  <GridColumn field='rnomeoperador' title='Operador' sortable={false} filterable={false} />, /* Track G.01 */

  <GridColumn field='nomeclientes' title='Clientes' sortable={false} filterable={false} />, /* Track G.01 */

  <GridColumn field='nropastaprocessos' title='Processos' sortable={false} filterable={false} />, /* Track G.01 */

  <GridColumn field='nometipocontatocrm' title='Tipo Contato C R M' sortable={false} filterable={false} />, /* Track G.01 */
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
  tableName: 'contatocrm'
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
  className='grid-desktop-contatocrm'
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