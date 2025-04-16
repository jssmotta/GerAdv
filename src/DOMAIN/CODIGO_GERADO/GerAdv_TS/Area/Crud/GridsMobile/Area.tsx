"use client";
import { Grid, GridColumn, GridFilterChangeEvent, GridPageChangeEvent, GridSortChangeEvent } from "@progress/kendo-react-all";
import { IArea } from "../../Interfaces/interface.Area";
import { useRouter } from 'next/navigation';
import { LoaderGrid } from "@/app/components/GridLoader";
import { useState } from "react";
import { applyFilter, applyFilterToColumn, sortData } from "@/app/tools/crud";

interface AreaGridProps {
	data: IArea[];
	onRowClick: (area: IArea) => void;
	onDeleteClick: (e: any) => void;
}

export const AreaGridMobileComponent: React.FC<AreaGridProps> = ({
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

const openConsultaAcao = (id: number) => {     
    router.push(`/pages/acao/?area=${id}`);    
};

const EditarCellAcao = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaAcao(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Acao' />&nbsp;</div>
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
            <div onClick={() => openConsultaAgenda(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Agenda' />&nbsp;</div>
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
            <div onClick={() => openConsultaAgendaFinanceiro(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Agenda Financeiro' />&nbsp;</div>
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
            <div onClick={() => openConsultaAreasJustica(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Areas Justica' />&nbsp;</div>
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
            <div onClick={() => openConsultaDivisaoTribunal(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Divisao Tribunal' />&nbsp;</div>
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
            <div onClick={() => openConsultaFase(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Fase' />&nbsp;</div>
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
            <div onClick={() => openConsultaObjetos(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Objetos' />&nbsp;</div>
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
            <div onClick={() => openConsultaPoderJudiciarioAssociado(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Poder Judiciario Associado' />&nbsp;</div>
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
            <div onClick={() => openConsultaProcessos(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Processos' />&nbsp;</div>
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
            <div onClick={() => openConsultaTipoRecurso(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Tipo Recurso' />&nbsp;</div>
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
            <div onClick={() => openConsultaTribunal(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Tribunal' />&nbsp;</div>
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
        title="Acao"
        cells={{ data: EditarCellAcao }}
      />
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
        title="Areas Justica"
        cells={{ data: EditarCellAreasJustica }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Divisao Tribunal"
        cells={{ data: EditarCellDivisaoTribunal }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Fase"
        cells={{ data: EditarCellFase }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Objetos"
        cells={{ data: EditarCellObjetos }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Poder Judiciario Associado"
        cells={{ data: EditarCellPoderJudiciarioAssociado }}
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
        title="Tipo Recurso"
        cells={{ data: EditarCellTipoRecurso }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Tribunal"
        cells={{ data: EditarCellTribunal }}
      />

			</Grid>
			{!data && (<LoaderGrid />)}
		</>
	);

};
