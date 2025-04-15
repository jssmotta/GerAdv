"use client";
import { Grid, GridColumn, GridFilterChangeEvent, GridPageChangeEvent, GridSortChangeEvent } from "@progress/kendo-react-all";
import { IOperador } from "../../Interfaces/interface.Operador";
import { useRouter } from 'next/navigation';
import { LoaderGrid } from "@/app/components/GridLoader";
import { useState } from "react";
import { applyFilter, applyFilterToColumn, sortData } from "@/app/tools/crud";

interface OperadorGridProps {
	data: IOperador[];
	onRowClick: (operador: IOperador) => void;
	onDeleteClick: (e: any) => void;
}

export const OperadorGridMobileComponent: React.FC<OperadorGridProps> = ({
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
		nome: ''
	});

	const handleSortChange = (e: GridSortChangeEvent) => {
		setSort(e.sort);
	};
	const filteredData = data.filter((data: any) => {
		const nomeMatches = applyFilter(data, 'nome', columnFilters.nome);

		return nomeMatches;
	});

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

const openConsultaAgenda = (id: number) => {     
    router.push(`/pages/agenda/?operador=${id}`);    
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
    router.push(`/pages/agendafinanceiro/?operador=${id}`);    
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
const openConsultaAlarmSMS = (id: number) => {     
    router.push(`/pages/alarmsms/?operador=${id}`);    
};

const EditarCellAlarmSMS = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaAlarmSMS(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Alarm S M S' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaAlertas = (id: number) => {     
    router.push(`/pages/alertas/?operador=${id}`);    
};

const EditarCellAlertas = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaAlertas(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Alertas' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaAlertasEnviados = (id: number) => {     
    router.push(`/pages/alertasenviados/?operador=${id}`);    
};

const EditarCellAlertasEnviados = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaAlertasEnviados(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Alertas Enviados' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaContatoCRM = (id: number) => {     
    router.push(`/pages/contatocrm/?operador=${id}`);    
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
const openConsultaContatoCRMOperador = (id: number) => {     
    router.push(`/pages/contatocrmoperador/?operador=${id}`);    
};

const EditarCellContatoCRMOperador = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaContatoCRMOperador(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Contato C R M Operador' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaDiario2 = (id: number) => {     
    router.push(`/pages/diario2/?operador=${id}`);    
};

const EditarCellDiario2 = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaDiario2(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Diario2' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaGUTAtividades = (id: number) => {     
    router.push(`/pages/gutatividades/?operador=${id}`);    
};

const EditarCellGUTAtividades = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaGUTAtividades(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar G U T Atividades' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaOperadorEMailPopup = (id: number) => {     
    router.push(`/pages/operadoremailpopup/?operador=${id}`);    
};

const EditarCellOperadorEMailPopup = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaOperadorEMailPopup(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Operador E Mail Popup' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaOperadorGrupo = (id: number) => {     
    router.push(`/pages/operadorgrupo/?operador=${id}`);    
};

const EditarCellOperadorGrupo = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaOperadorGrupo(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Operador Grupo' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaOperadorGruposAgenda = (id: number) => {     
    router.push(`/pages/operadorgruposagenda/?operador=${id}`);    
};

const EditarCellOperadorGruposAgenda = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaOperadorGruposAgenda(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Operador Grupos Agenda' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaOperadorGruposAgendaOperadores = (id: number) => {     
    router.push(`/pages/operadorgruposagendaoperadores/?operador=${id}`);    
};

const EditarCellOperadorGruposAgendaOperadores = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaOperadorGruposAgendaOperadores(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Operador Grupos Agenda Operadores' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaPontoVirtual = (id: number) => {     
    router.push(`/pages/pontovirtual/?operador=${id}`);    
};

const EditarCellPontoVirtual = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaPontoVirtual(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Ponto Virtual' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaPontoVirtualAcessos = (id: number) => {     
    router.push(`/pages/pontovirtualacessos/?operador=${id}`);    
};

const EditarCellPontoVirtualAcessos = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaPontoVirtualAcessos(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Ponto Virtual Acessos' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaProcessosParados = (id: number) => {     
    router.push(`/pages/processosparados/?operador=${id}`);    
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
    router.push(`/pages/processoutputrequest/?operador=${id}`);    
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
const openConsultaReuniaoPessoas = (id: number) => {     
    router.push(`/pages/reuniaopessoas/?operador=${id}`);    
};

const EditarCellReuniaoPessoas = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaReuniaoPessoas(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Reuniao Pessoas' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaSMSAlice = (id: number) => {     
    router.push(`/pages/smsalice/?operador=${id}`);    
};

const EditarCellSMSAlice = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaSMSAlice(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar S M S Alice' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaStatusBiu = (id: number) => {     
    router.push(`/pages/statusbiu/?operador=${id}`);    
};

const EditarCellStatusBiu = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaStatusBiu(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Status Biu' />&nbsp;</div>
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
				<GridColumn field="nome" title="Nome" />
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
        title="Alarm S M S"
        cells={{ data: EditarCellAlarmSMS }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Alertas"
        cells={{ data: EditarCellAlertas }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Alertas Enviados"
        cells={{ data: EditarCellAlertasEnviados }}
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
        title="Contato C R M Operador"
        cells={{ data: EditarCellContatoCRMOperador }}
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
        title="G U T Atividades"
        cells={{ data: EditarCellGUTAtividades }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Operador E Mail Popup"
        cells={{ data: EditarCellOperadorEMailPopup }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Operador Grupo"
        cells={{ data: EditarCellOperadorGrupo }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Operador Grupos Agenda"
        cells={{ data: EditarCellOperadorGruposAgenda }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Operador Grupos Agenda Operadores"
        cells={{ data: EditarCellOperadorGruposAgendaOperadores }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Ponto Virtual"
        cells={{ data: EditarCellPontoVirtual }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Ponto Virtual Acessos"
        cells={{ data: EditarCellPontoVirtualAcessos }}
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
        title="Reuniao Pessoas"
        cells={{ data: EditarCellReuniaoPessoas }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="S M S Alice"
        cells={{ data: EditarCellSMSAlice }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Status Biu"
        cells={{ data: EditarCellStatusBiu }}
      />

			</Grid>
			{!data && (<LoaderGrid />)}
		</>
	);

};
