// GridsDesktop.tsx.txt
'use client';
import React from 'react';
import { Grid, GridColumn, GridFilterChangeEvent, GridPageChangeEvent, GridSortChangeEvent } from '@progress/kendo-react-grid';
import { ILigacoes } from '../../Interfaces/interface.Ligacoes';
import { useRouter } from 'next/navigation';
import { useEffect, useState, useMemo } from 'react';
import { applyFilter, applyFilterToColumn, CRUD_CONSTANTS, sortData } from '@/app/tools/crud';
import { SvgIcon } from '@progress/kendo-react-common';
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';
interface LigacoesGridProps {
  data: ILigacoes[];
  onRowClick: (ligacoes: ILigacoes) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const LigacoesGridDesktopComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: LigacoesGridProps) => {
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

const openConsultaRecados = (id: number) => {
  router.push(`/pages/recados/?ligacoes=${id}`);
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
const MaskligDataRealizadaCell = (props: any) => {
  const valor = props.dataItem[props.field];
  const formattedValue = valor ? valor.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' }) : 'R$ 0,00';
  return <td>{formattedValue}</td>;
};
const MaskligRealizadaCell = (props: any) => {
  const valor = props.dataItem[props.field];
  const formattedValue = valor ? valor.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' }) : 'R$ 0,00';
  return <td>{formattedValue}</td>;
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
title='Recados'
cells={{ data: EditarCellRecados }}
/>
<GridColumn field='nomeclientes' title='Clientes' sortable={false} filterable={false} /> {/* Track G.01 */}

<GridColumn field='nomeramal' title='Ramal' sortable={false} filterable={false} /> {/* Track G.01 */}

<GridColumn field='nropastaprocessos' title='Processos' sortable={false} filterable={false} /> {/* Track G.01 */}
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