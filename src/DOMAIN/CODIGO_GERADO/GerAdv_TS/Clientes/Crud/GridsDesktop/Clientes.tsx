// GridsDesktop.tsx.txt
"use client";
import { Grid, GridColumn, GridFilterChangeEvent, GridPageChangeEvent, GridSortChangeEvent } from "@progress/kendo-react-all";
import { IClientes } from "../../Interfaces/interface.Clientes";
import { useRouter } from 'next/navigation';
import { LoaderGrid } from "@/app/components/Cruds/GridLoader";
import { useState } from "react";
import { applyFilter, applyFilterToColumn, sortData } from "@/app/tools/crud";
import { SvgIcon } from "@progress/kendo-react-common";
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';

interface ClientesGridProps {
	data: IClientes[];
	onRowClick: (clientes: IClientes) => void;
	onDeleteClick: (e: any) => void;
	setSelectedId: (id: number | null) => void;
}

export const ClientesGridDesktopComponent: React.FC<ClientesGridProps> = ({
	data,
	onRowClick,
	onDeleteClick,
	setSelectedId,
}) => {
	const router = useRouter();

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
	const filteredData = data.filter((data: any) => {
		const nomeMatches = applyFilter(data, 'nome', columnFilters.nome);

		return nomeMatches
;
	});

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

const openConsultaAgenda = (id: number) => {     
    router.push(`/pages/agenda/?clientes=${id}`);    
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
    router.push(`/pages/agendafinanceiro/?clientes=${id}`);    
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
const openConsultaAgendaRepetir = (id: number) => {     
    router.push(`/pages/agendarepetir/?clientes=${id}`);    
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
const openConsultaAnexamentoRegistros = (id: number) => {     
    router.push(`/pages/anexamentoregistros/?clientes=${id}`);    
};

const EditarCellAnexamentoRegistros = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaAnexamentoRegistros(props.dataItem.id)}><span title='Editar Anexamento Registros'><SvgIcon icon={pencilIcon} /></span></div>
        </td>
      </>
    );
}; 
const openConsultaClientesSocios = (id: number) => {     
    router.push(`/pages/clientessocios/?clientes=${id}`);    
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
    router.push(`/pages/colaboradores/?clientes=${id}`);    
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
const openConsultaContaCorrente = (id: number) => {     
    router.push(`/pages/contacorrente/?clientes=${id}`);    
};

const EditarCellContaCorrente = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaContaCorrente(props.dataItem.id)}><span title='Editar Conta Corrente'><SvgIcon icon={pencilIcon} /></span></div>
        </td>
      </>
    );
}; 
const openConsultaContatoCRM = (id: number) => {     
    router.push(`/pages/contatocrm/?clientes=${id}`);    
};

const EditarCellContatoCRM = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaContatoCRM(props.dataItem.id)}><span title='Editar Contato C R M'><SvgIcon icon={pencilIcon} /></span></div>
        </td>
      </>
    );
}; 
const openConsultaContratos = (id: number) => {     
    router.push(`/pages/contratos/?clientes=${id}`);    
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
const openConsultaDadosProcuracao = (id: number) => {     
    router.push(`/pages/dadosprocuracao/?clientes=${id}`);    
};

const EditarCellDadosProcuracao = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaDadosProcuracao(props.dataItem.id)}><span title='Editar Dados Procuracao'><SvgIcon icon={pencilIcon} /></span></div>
        </td>
      </>
    );
}; 
const openConsultaDiario2 = (id: number) => {     
    router.push(`/pages/diario2/?clientes=${id}`);    
};

const EditarCellDiario2 = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaDiario2(props.dataItem.id)}><span title='Editar Diario2'><SvgIcon icon={pencilIcon} /></span></div>
        </td>
      </>
    );
}; 
const openConsultaGruposEmpresas = (id: number) => {     
    router.push(`/pages/gruposempresas/?clientes=${id}`);    
};

const EditarCellGruposEmpresas = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaGruposEmpresas(props.dataItem.id)}><span title='Editar Grupos Empresas'><SvgIcon icon={pencilIcon} /></span></div>
        </td>
      </>
    );
}; 
const openConsultaGruposEmpresasCli = (id: number) => {     
    router.push(`/pages/gruposempresascli/?clientes=${id}`);    
};

const EditarCellGruposEmpresasCli = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaGruposEmpresasCli(props.dataItem.id)}><span title='Editar Grupos Empresas Cli'><SvgIcon icon={pencilIcon} /></span></div>
        </td>
      </>
    );
}; 
const openConsultaHonorariosDadosContrato = (id: number) => {     
    router.push(`/pages/honorariosdadoscontrato/?clientes=${id}`);    
};

const EditarCellHonorariosDadosContrato = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaHonorariosDadosContrato(props.dataItem.id)}><span title='Editar Honorarios Dados Contrato'><SvgIcon icon={pencilIcon} /></span></div>
        </td>
      </>
    );
}; 
const openConsultaHorasTrab = (id: number) => {     
    router.push(`/pages/horastrab/?clientes=${id}`);    
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
const openConsultaLigacoes = (id: number) => {     
    router.push(`/pages/ligacoes/?clientes=${id}`);    
};

const EditarCellLigacoes = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaLigacoes(props.dataItem.id)}><span title='Editar Ligacoes'><SvgIcon icon={pencilIcon} /></span></div>
        </td>
      </>
    );
}; 
const openConsultaLivroCaixaClientes = (id: number) => {     
    router.push(`/pages/livrocaixaclientes/?clientes=${id}`);    
};

const EditarCellLivroCaixaClientes = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaLivroCaixaClientes(props.dataItem.id)}><span title='Editar Livro Caixa Clientes'><SvgIcon icon={pencilIcon} /></span></div>
        </td>
      </>
    );
}; 
const openConsultaOperadores = (id: number) => {     
    router.push(`/pages/operadores/?clientes=${id}`);    
};

const EditarCellOperadores = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaOperadores(props.dataItem.id)}><span title='Editar Operadores'><SvgIcon icon={pencilIcon} /></span></div>
        </td>
      </>
    );
}; 
const openConsultaPreClientes = (id: number) => {     
    router.push(`/pages/preclientes/?clientes=${id}`);    
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
const openConsultaProcessos = (id: number) => {     
    router.push(`/pages/processos/?clientes=${id}`);    
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
const openConsultaProDespesas = (id: number) => {     
    router.push(`/pages/prodespesas/?clientes=${id}`);    
};

const EditarCellProDespesas = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaProDespesas(props.dataItem.id)}><span title='Editar Pro Despesas'><SvgIcon icon={pencilIcon} /></span></div>
        </td>
      </>
    );
}; 
const openConsultaRecados = (id: number) => {     
    router.push(`/pages/recados/?clientes=${id}`);    
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
const openConsultaReuniao = (id: number) => {     
    router.push(`/pages/reuniao/?clientes=${id}`);    
};

const EditarCellReuniao = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaReuniao(props.dataItem.id)}><span title='Editar Reuniao'><SvgIcon icon={pencilIcon} /></span></div>
        </td>
      </>
    );
}; 
const openConsultaAgendaSemana = (id: number) => {     
    router.push(`/pages/agendasemana/?clientes=${id}`);    
};

const EditarCellAgendaSemana = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaAgendaSemana(props.dataItem.id)}><span title='Editar Agenda Semana'><SvgIcon icon={pencilIcon} /></span></div>
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
					pageSizes: [10, 15, 30, 50, 100],
					buttonCount: 5,
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
				<GridColumn field="index" title="#" sortable={false} filterable={false} width="55px" cells={{ data: RowNumberCell }} />
			
				<GridColumn field="nome" title="Nome" sortable={true} filterable={true} />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Agenda"
        cells={{ data: EditarCellAgenda }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Agenda Financeiro"
        cells={{ data: EditarCellAgendaFinanceiro }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Agenda Repetir"
        cells={{ data: EditarCellAgendaRepetir }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Anexamento Registros"
        cells={{ data: EditarCellAnexamentoRegistros }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Clientes Socios"
        cells={{ data: EditarCellClientesSocios }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Colaboradores"
        cells={{ data: EditarCellColaboradores }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Conta Corrente"
        cells={{ data: EditarCellContaCorrente }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Contato C R M"
        cells={{ data: EditarCellContatoCRM }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Contratos"
        cells={{ data: EditarCellContratos }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Dados Procuracao"
        cells={{ data: EditarCellDadosProcuracao }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Diario2"
        cells={{ data: EditarCellDiario2 }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Grupos Empresas"
        cells={{ data: EditarCellGruposEmpresas }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Grupos Empresas Cli"
        cells={{ data: EditarCellGruposEmpresasCli }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Honorarios Dados Contrato"
        cells={{ data: EditarCellHonorariosDadosContrato }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Horas Trab"
        cells={{ data: EditarCellHorasTrab }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Ligacoes"
        cells={{ data: EditarCellLigacoes }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Livro Caixa Clientes"
        cells={{ data: EditarCellLivroCaixaClientes }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Operadores"
        cells={{ data: EditarCellOperadores }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Pre Clientes"
        cells={{ data: EditarCellPreClientes }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Processos"
        cells={{ data: EditarCellProcessos }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Pro Despesas"
        cells={{ data: EditarCellProDespesas }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Recados"
        cells={{ data: EditarCellRecados }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Reuniao"
        cells={{ data: EditarCellReuniao }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Agenda Semana"
        cells={{ data: EditarCellAgendaSemana }}
      />
<GridColumn 	
			field="id" 
			width={'55px'}
			title="Excluir"
			sortable={false} filterable={false}
			cells={{ data: ExcluirLinha }} />

			</Grid>
			{!data && (<LoaderGrid />)}
		</>
	);

};
