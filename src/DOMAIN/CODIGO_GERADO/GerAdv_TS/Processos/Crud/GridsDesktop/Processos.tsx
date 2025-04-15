"use client";
import { Grid, GridColumn, GridFilterChangeEvent, GridPageChangeEvent, GridSortChangeEvent } from "@progress/kendo-react-all";
import { IProcessos } from "../../Interfaces/interface.Processos";
import { useRouter } from 'next/navigation';
import { LoaderGrid } from "@/app/components/GridLoader";
import { useState } from "react";
import { applyFilter, applyFilterToColumn, sortData } from "@/app/tools/crud";

interface ProcessosGridProps {
	data: IProcessos[];
	onRowClick: (processos: IProcessos) => void;
	onDeleteClick: (e: any) => void;
}

export const ProcessosGridDesktopComponent: React.FC<ProcessosGridProps> = ({
	data,
	onRowClick,
	onDeleteClick
}) => {
	const router = useRouter();

	const RowNumberCell = (props: any) => <td>{props.dataIndex + 1}</td>;	

	const [page, setPage] = useState({
		skip: 0,
		take: 10,
	});
	const [sort, setSort] = useState<any[]>([]);

	const [columnFilters, setColumnFilters] = useState({
		nropasta: '',

	});

	const handleSortChange = (e: GridSortChangeEvent) => {
		setSort(e.sort);
	};
	const filteredData = data.filter((data: any) => {
		const nropastaMatches = applyFilter(data, 'nropasta', columnFilters.nropasta);

		return nropastaMatches
;
	});

	const handleFilterChange = (event: GridFilterChangeEvent) => {
		const filters = event.filter?.filters || [];
		const newColumnFilters = { nropasta: '',
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
    router.push(`/pages/agenda/?processos=${id}`);    
};

const EditarCellAgenda = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaAgenda(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Agenda' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaAgendaFinanceiro = (id: number) => {     
    router.push(`/pages/agendafinanceiro/?processos=${id}`);    
};

const EditarCellAgendaFinanceiro = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaAgendaFinanceiro(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Agenda Financeiro' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaAgendaRepetir = (id: number) => {     
    router.push(`/pages/agendarepetir/?processos=${id}`);    
};

const EditarCellAgendaRepetir = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaAgendaRepetir(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Agenda Repetir' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaAndamentosMD = (id: number) => {     
    router.push(`/pages/andamentosmd/?processos=${id}`);    
};

const EditarCellAndamentosMD = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaAndamentosMD(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Andamentos M D' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaApenso = (id: number) => {     
    router.push(`/pages/apenso/?processos=${id}`);    
};

const EditarCellApenso = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaApenso(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Apenso' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaApenso2 = (id: number) => {     
    router.push(`/pages/apenso2/?processos=${id}`);    
};

const EditarCellApenso2 = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaApenso2(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Apenso2' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaContaCorrente = (id: number) => {     
    router.push(`/pages/contacorrente/?processos=${id}`);    
};

const EditarCellContaCorrente = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaContaCorrente(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Conta Corrente' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaContatoCRM = (id: number) => {     
    router.push(`/pages/contatocrm/?processos=${id}`);    
};

const EditarCellContatoCRM = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaContatoCRM(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Contato C R M' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaContratos = (id: number) => {     
    router.push(`/pages/contratos/?processos=${id}`);    
};

const EditarCellContratos = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaContratos(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Contratos' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaDocumentos = (id: number) => {     
    router.push(`/pages/documentos/?processos=${id}`);    
};

const EditarCellDocumentos = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaDocumentos(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Documentos' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaEnderecoSistema = (id: number) => {     
    router.push(`/pages/enderecosistema/?processos=${id}`);    
};

const EditarCellEnderecoSistema = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaEnderecoSistema(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Endereco Sistema' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaHistorico = (id: number) => {     
    router.push(`/pages/historico/?processos=${id}`);    
};

const EditarCellHistorico = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaHistorico(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Historico' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaHonorariosDadosContrato = (id: number) => {     
    router.push(`/pages/honorariosdadoscontrato/?processos=${id}`);    
};

const EditarCellHonorariosDadosContrato = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaHonorariosDadosContrato(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Honorarios Dados Contrato' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaHorasTrab = (id: number) => {     
    router.push(`/pages/horastrab/?processos=${id}`);    
};

const EditarCellHorasTrab = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaHorasTrab(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Horas Trab' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaInstancia = (id: number) => {     
    router.push(`/pages/instancia/?processos=${id}`);    
};

const EditarCellInstancia = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaInstancia(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Instancia' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaLigacoes = (id: number) => {     
    router.push(`/pages/ligacoes/?processos=${id}`);    
};

const EditarCellLigacoes = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaLigacoes(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Ligacoes' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaLivroCaixa = (id: number) => {     
    router.push(`/pages/livrocaixa/?processos=${id}`);    
};

const EditarCellLivroCaixa = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaLivroCaixa(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Livro Caixa' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaNENotas = (id: number) => {     
    router.push(`/pages/nenotas/?processos=${id}`);    
};

const EditarCellNENotas = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaNENotas(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar N E Notas' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaParceriaProc = (id: number) => {     
    router.push(`/pages/parceriaproc/?processos=${id}`);    
};

const EditarCellParceriaProc = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaParceriaProc(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Parceria Proc' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaParteCliente = (id: number) => {     
    router.push(`/pages/partecliente/?processos=${id}`);    
};

const EditarCellParteCliente = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaParteCliente(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Parte Cliente' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaParteClienteOutras = (id: number) => {     
    router.push(`/pages/parteclienteoutras/?processos=${id}`);    
};

const EditarCellParteClienteOutras = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaParteClienteOutras(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Parte Cliente Outras' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaParteOponente = (id: number) => {     
    router.push(`/pages/parteoponente/?processos=${id}`);    
};

const EditarCellParteOponente = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaParteOponente(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Parte Oponente' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaPenhora = (id: number) => {     
    router.push(`/pages/penhora/?processos=${id}`);    
};

const EditarCellPenhora = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaPenhora(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Penhora' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaPrecatoria = (id: number) => {     
    router.push(`/pages/precatoria/?processos=${id}`);    
};

const EditarCellPrecatoria = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaPrecatoria(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Precatoria' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaProBarCODE = (id: number) => {     
    router.push(`/pages/probarcode/?processos=${id}`);    
};

const EditarCellProBarCODE = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaProBarCODE(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Pro Bar C O D E' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaProCDA = (id: number) => {     
    router.push(`/pages/procda/?processos=${id}`);    
};

const EditarCellProCDA = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaProCDA(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Pro C D A' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaProcessosObsReport = (id: number) => {     
    router.push(`/pages/processosobsreport/?processos=${id}`);    
};

const EditarCellProcessosObsReport = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaProcessosObsReport(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Processos Obs Report' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaProcessosParados = (id: number) => {     
    router.push(`/pages/processosparados/?processos=${id}`);    
};

const EditarCellProcessosParados = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaProcessosParados(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Processos Parados' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaProcessOutputRequest = (id: number) => {     
    router.push(`/pages/processoutputrequest/?processos=${id}`);    
};

const EditarCellProcessOutputRequest = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaProcessOutputRequest(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Process Output Request' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaProDepositos = (id: number) => {     
    router.push(`/pages/prodepositos/?processos=${id}`);    
};

const EditarCellProDepositos = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaProDepositos(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Pro Depositos' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaProDespesas = (id: number) => {     
    router.push(`/pages/prodespesas/?processos=${id}`);    
};

const EditarCellProDespesas = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaProDespesas(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Pro Despesas' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaProObservacoes = (id: number) => {     
    router.push(`/pages/proobservacoes/?processos=${id}`);    
};

const EditarCellProObservacoes = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaProObservacoes(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Pro Observacoes' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaProPartes = (id: number) => {     
    router.push(`/pages/propartes/?processos=${id}`);    
};

const EditarCellProPartes = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaProPartes(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Pro Partes' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaProProcuradores = (id: number) => {     
    router.push(`/pages/proprocuradores/?processos=${id}`);    
};

const EditarCellProProcuradores = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaProProcuradores(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Pro Procuradores' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaProResumos = (id: number) => {     
    router.push(`/pages/proresumos/?processos=${id}`);    
};

const EditarCellProResumos = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaProResumos(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Pro Resumos' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaProSucumbencia = (id: number) => {     
    router.push(`/pages/prosucumbencia/?processos=${id}`);    
};

const EditarCellProSucumbencia = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaProSucumbencia(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Pro Sucumbencia' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaProValores = (id: number) => {     
    router.push(`/pages/provalores/?processos=${id}`);    
};

const EditarCellProValores = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaProValores(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Pro Valores' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaRecados = (id: number) => {     
    router.push(`/pages/recados/?processos=${id}`);    
};

const EditarCellRecados = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaRecados(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Recados' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaTerceiros = (id: number) => {     
    router.push(`/pages/terceiros/?processos=${id}`);    
};

const EditarCellTerceiros = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaTerceiros(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Terceiros' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaUltimosProcessos = (id: number) => {     
    router.push(`/pages/ultimosprocessos/?processos=${id}`);    
};

const EditarCellUltimosProcessos = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaUltimosProcessos(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Ultimos Processos' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaAgendaRelatorio = (id: number) => {     
    router.push(`/pages/agendarelatorio/?processos=${id}`);    
};

const EditarCellAgendaRelatorio = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaAgendaRelatorio(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Agenda Relatorio' />&nbsp;</div>
        </td>
      </>
    );
};
 
	const ExcluirLinha = (e: any) => {
		return (
			<td>
				
				<img onClick={() => onDeleteClick(e) } src='https://cdn.menphis.com.br/msi/v20/excluir3.webp' alt="Excluir" width="20" height="20" />
				
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
			
				<GridColumn field="nropasta" title="NroPasta" sortable={true} filterable={true} />
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
        title="Andamentos M D"
        cells={{ data: EditarCellAndamentosMD }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Apenso"
        cells={{ data: EditarCellApenso }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Apenso2"
        cells={{ data: EditarCellApenso2 }}
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
        title="Documentos"
        cells={{ data: EditarCellDocumentos }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Endereco Sistema"
        cells={{ data: EditarCellEnderecoSistema }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Historico"
        cells={{ data: EditarCellHistorico }}
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
        title="Instancia"
        cells={{ data: EditarCellInstancia }}
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
        title="Livro Caixa"
        cells={{ data: EditarCellLivroCaixa }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="N E Notas"
        cells={{ data: EditarCellNENotas }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Parceria Proc"
        cells={{ data: EditarCellParceriaProc }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Parte Cliente"
        cells={{ data: EditarCellParteCliente }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Parte Cliente Outras"
        cells={{ data: EditarCellParteClienteOutras }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Parte Oponente"
        cells={{ data: EditarCellParteOponente }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Penhora"
        cells={{ data: EditarCellPenhora }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Precatoria"
        cells={{ data: EditarCellPrecatoria }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Pro Bar C O D E"
        cells={{ data: EditarCellProBarCODE }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Pro C D A"
        cells={{ data: EditarCellProCDA }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Processos Obs Report"
        cells={{ data: EditarCellProcessosObsReport }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Processos Parados"
        cells={{ data: EditarCellProcessosParados }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Process Output Request"
        cells={{ data: EditarCellProcessOutputRequest }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Pro Depositos"
        cells={{ data: EditarCellProDepositos }}
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
        title="Pro Observacoes"
        cells={{ data: EditarCellProObservacoes }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Pro Partes"
        cells={{ data: EditarCellProPartes }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Pro Procuradores"
        cells={{ data: EditarCellProProcuradores }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Pro Resumos"
        cells={{ data: EditarCellProResumos }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Pro Sucumbencia"
        cells={{ data: EditarCellProSucumbencia }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Pro Valores"
        cells={{ data: EditarCellProValores }}
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
        title="Terceiros"
        cells={{ data: EditarCellTerceiros }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Ultimos Processos"
        cells={{ data: EditarCellUltimosProcessos }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Agenda Relatorio"
        cells={{ data: EditarCellAgendaRelatorio }}
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
