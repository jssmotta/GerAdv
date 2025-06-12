// GridsMobile.tsx.txt
'use client';
import React from 'react';
import { Grid, GridColumn, GridFilterChangeEvent, GridPageChangeEvent, GridSortChangeEvent } from '@progress/kendo-react-grid';
import { ICidade } from '../../Interfaces/interface.Cidade';
import { useRouter } from 'next/navigation';
import { useEffect, useState, useMemo } from 'react';
import { applyFilter, applyFilterToColumn, CRUD_CONSTANTS, sortData } from '@/app/tools/crud';
import { SvgIcon } from '@progress/kendo-react-common';
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';
interface CidadeGridProps {
  data: ICidade[];
  onRowClick: (cidade: ICidade) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const CidadeGridMobileComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: CidadeGridProps) => {
const router = useRouter();
const [initialized, setInitialized] = useState(false);
const RowNumberCell = (props: any) => <td>{props.dataIndex + 1}</td>;
const [page, setPage] = useState({
  skip: 0, 
  take: 10, 
});
const [sort, setSort] = useState<any[]>([]);
const [columnFilters, setColumnFilters] = useState({
  nome: ''
});
const handleSortChange = (e: GridSortChangeEvent) => {
  setSort(e.sort);
};
const filteredData = useMemo(() => { return data.filter((data: any) => {
  const nomeMatches = applyFilter(data, 'nome', columnFilters.nome);
  return nomeMatches;
});
}, [data, columnFilters]);
const handleFilterChange = (event: GridFilterChangeEvent) => {
  const filters = event.filter?.filters || [];
  const newColumnFilters = { nome: '' };
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

const openConsultaAdvogados = (id: number) => {
  router.push(`/pages/advogados/?cidade=${id}`);
};
const EditarCellAdvogados = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaAdvogados(props.dataItem.id)}><span title='Editar Advogados'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaAgenda = (id: number) => {
  router.push(`/pages/agenda/?cidade=${id}`);
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
  router.push(`/pages/agendafinanceiro/?cidade=${id}`);
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
const openConsultaBensMateriais = (id: number) => {
  router.push(`/pages/bensmateriais/?cidade=${id}`);
};
const EditarCellBensMateriais = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaBensMateriais(props.dataItem.id)}><span title='Editar Bens Materiais'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaClientes = (id: number) => {
  router.push(`/pages/clientes/?cidade=${id}`);
};
const EditarCellClientes = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaClientes(props.dataItem.id)}><span title='Editar Clientes'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaClientesSocios = (id: number) => {
  router.push(`/pages/clientessocios/?cidade=${id}`);
};
const EditarCellClientesSocios = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaClientesSocios(props.dataItem.id)}><span title='Editar Clientes Socios'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaColaboradores = (id: number) => {
  router.push(`/pages/colaboradores/?cidade=${id}`);
};
const EditarCellColaboradores = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaColaboradores(props.dataItem.id)}><span title='Editar Colaboradores'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaDivisaoTribunal = (id: number) => {
  router.push(`/pages/divisaotribunal/?cidade=${id}`);
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
const openConsultaEnderecos = (id: number) => {
  router.push(`/pages/enderecos/?cidade=${id}`);
};
const EditarCellEnderecos = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaEnderecos(props.dataItem.id)}><span title='Editar Endereços'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaEnderecoSistema = (id: number) => {
  router.push(`/pages/enderecosistema/?cidade=${id}`);
};
const EditarCellEnderecoSistema = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaEnderecoSistema(props.dataItem.id)}><span title='Editar Endereco Sistema'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaEscritorios = (id: number) => {
  router.push(`/pages/escritorios/?cidade=${id}`);
};
const EditarCellEscritorios = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaEscritorios(props.dataItem.id)}><span title='Editar Escritorios'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaFornecedores = (id: number) => {
  router.push(`/pages/fornecedores/?cidade=${id}`);
};
const EditarCellFornecedores = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaFornecedores(props.dataItem.id)}><span title='Editar Fornecedores'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaForo = (id: number) => {
  router.push(`/pages/foro/?cidade=${id}`);
};
const EditarCellForo = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaForo(props.dataItem.id)}><span title='Editar Foro'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaFuncionarios = (id: number) => {
  router.push(`/pages/funcionarios/?cidade=${id}`);
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
const openConsultaOponentes = (id: number) => {
  router.push(`/pages/oponentes/?cidade=${id}`);
};
const EditarCellOponentes = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaOponentes(props.dataItem.id)}><span title='Editar Oponentes'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaOponentesRepLegal = (id: number) => {
  router.push(`/pages/oponentesreplegal/?cidade=${id}`);
};
const EditarCellOponentesRepLegal = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaOponentesRepLegal(props.dataItem.id)}><span title='Editar Oponentes Rep Legal'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaOutrasPartesCliente = (id: number) => {
  router.push(`/pages/outraspartescliente/?cidade=${id}`);
};
const EditarCellOutrasPartesCliente = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaOutrasPartesCliente(props.dataItem.id)}><span title='Editar Outras Partes Cliente'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaPoderJudiciarioAssociado = (id: number) => {
  router.push(`/pages/poderjudiciarioassociado/?cidade=${id}`);
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
const openConsultaPreClientes = (id: number) => {
  router.push(`/pages/preclientes/?cidade=${id}`);
};
const EditarCellPreClientes = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaPreClientes(props.dataItem.id)}><span title='Editar Pre Clientes'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaPrepostos = (id: number) => {
  router.push(`/pages/prepostos/?cidade=${id}`);
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
const openConsultaProcessos = (id: number) => {
  router.push(`/pages/processos/?cidade=${id}`);
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
const openConsultaTerceiros = (id: number) => {
  router.push(`/pages/terceiros/?cidade=${id}`);
};
const EditarCellTerceiros = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaTerceiros(props.dataItem.id)}><span title='Editar Terceiros'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaTribEnderecos = (id: number) => {
  router.push(`/pages/tribenderecos/?cidade=${id}`);
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
onRowClick={(e) => handleRowClick(e)}>
<GridColumn field='index' title='#' sortable={false} filterable={false} width='55px' cells={{ data: RowNumberCell }} />
<GridColumn field='nome' title='Nome' />
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Advogados'
cells={{ data: EditarCellAdvogados }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Agenda'
cells={{ data: EditarCellAgenda }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Agenda Financeiro'
cells={{ data: EditarCellAgendaFinanceiro }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Bens Materiais'
cells={{ data: EditarCellBensMateriais }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Clientes'
cells={{ data: EditarCellClientes }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Clientes Socios'
cells={{ data: EditarCellClientesSocios }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Colaboradores'
cells={{ data: EditarCellColaboradores }}
/>
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
title='Endereços'
cells={{ data: EditarCellEnderecos }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Endereco Sistema'
cells={{ data: EditarCellEnderecoSistema }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Escritorios'
cells={{ data: EditarCellEscritorios }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Fornecedores'
cells={{ data: EditarCellFornecedores }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Foro'
cells={{ data: EditarCellForo }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Colaborador'
cells={{ data: EditarCellFuncionarios }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Oponentes'
cells={{ data: EditarCellOponentes }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Oponentes Rep Legal'
cells={{ data: EditarCellOponentesRepLegal }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Outras Partes Cliente'
cells={{ data: EditarCellOutrasPartesCliente }}
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
title='Pre Clientes'
cells={{ data: EditarCellPreClientes }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Prepostos'
cells={{ data: EditarCellPrepostos }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Processos'
cells={{ data: EditarCellProcessos }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Terceiros'
cells={{ data: EditarCellTerceiros }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Trib Endereços'
cells={{ data: EditarCellTribEnderecos }}
/>
</Grid>

</>
);
}
);