// GridsDesktop.tsx.txt
'use client';
import React from 'react';
import { Grid, GridColumn, GridFilterChangeEvent, GridPageChangeEvent, GridSortChangeEvent } from '@progress/kendo-react-grid';
import { ITribunal } from '../../Interfaces/interface.Tribunal';
import { useRouter } from 'next/navigation';
import { useEffect, useState, useMemo } from 'react';
import { applyFilter, applyFilterToColumn, CRUD_CONSTANTS, sortData } from '@/app/tools/crud';
import { SvgIcon } from '@progress/kendo-react-common';
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';
interface TribunalGridProps {
  data: ITribunal[];
  onRowClick: (tribunal: ITribunal) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const TribunalGridDesktopComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: TribunalGridProps) => {
const router = useRouter();
const [initialized, setInitialized] = useState(false);
const RowNumberCell = (props: any) => <td>{props.dataIndex + 1}</td>;
const [page, setPage] = useState({
  skip: 0, 
  take: 10, 
});
const [sort, setSort] = useState<any[]>([]);
const [columnFilters, setColumnFilters] = useState({
  nome: '',
});
const handleSortChange = (e: GridSortChangeEvent) => {
  setSort(e.sort);
};
const filteredData = useMemo(() => {
  return data.filter((data: any) => {
    const nomeMatches = applyFilter(data, 'nome', columnFilters.nome);
    return nomeMatches
    ;
  });
}, [data, columnFilters]);
const handleFilterChange = (event: GridFilterChangeEvent) => {
  const filters = event.filter?.filters || [];
  const newColumnFilters = { nome: '',
  };
  filters.forEach((filter) => applyFilterToColumn(filter, newColumnFilters));
  setColumnFilters(newColumnFilters);
};
const sortedFilteredData = sortData(filteredData, sort);
const handlePageChange = (event: GridPageChangeEvent) => {
  setPage({
    skip: event.page.skip, 
    take: event.page.take, 
  });
};
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
data={sortedFilteredData.slice(page.skip, page.skip + page.take)}
skip={page.skip}
take={page.take}
total={sortedFilteredData.length}
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
<GridColumn field='index' title='#' sortable={false} filterable={false} width='55px' cells={{ data: RowNumberCell }} />

<GridColumn field='nome' title='Nome' sortable={true} filterable={true} />  {/* Track G.02 */}
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Divisao Tribunal'
cells={{ data: EditarCellDivisaoTribunal }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Poder Judiciario Associado'
cells={{ data: EditarCellPoderJudiciarioAssociado }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Trib Endereços'
cells={{ data: EditarCellTribEnderecos }}
/>
<GridColumn field='descricaoarea' title='Area' sortable={false} filterable={false} /> {/* Track G.01 */}

<GridColumn field='nomejustica' title='Justica' sortable={false} filterable={false} /> {/* Track G.01 */}

<GridColumn field='nroprocessoinstancia' title='Instancia' sortable={false} filterable={false} /> {/* Track G.01 */}
<GridColumn
field='id'
width={'55px'}
title='Excluir'
sortable={false} filterable={false}
cells={{ data: ExcluirLinha }} />
</Grid>

</>
);
}
);