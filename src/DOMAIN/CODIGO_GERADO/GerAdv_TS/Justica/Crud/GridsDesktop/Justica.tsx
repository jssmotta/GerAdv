// GridsDesktop.tsx.txt
"use client";
import { Grid, GridColumn, GridFilterChangeEvent, GridPageChangeEvent, GridSortChangeEvent } from "@progress/kendo-react-all";
import { IJustica } from "../../Interfaces/interface.Justica";
import { useRouter } from 'next/navigation';
import { LoaderGrid } from "@/app/components/Cruds/GridLoader";
import { useState } from "react";
import { applyFilter, applyFilterToColumn, sortData } from "@/app/tools/crud";
import { SvgIcon } from "@progress/kendo-react-common";
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';

interface JusticaGridProps {
	data: IJustica[];
	onRowClick: (justica: IJustica) => void;
	onDeleteClick: (e: any) => void;
	setSelectedId: (id: number | null) => void;
}

export const JusticaGridDesktopComponent: React.FC<JusticaGridProps> = ({
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

const openConsultaAcao = (id: number) => {     
    router.push(`/pages/acao/?justica=${id}`);    
};

const EditarCellAcao = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaAcao(props.dataItem.id)}><span title='Editar Acao'><SvgIcon icon={pencilIcon} /></span></div>
        </td>
      </>
    );
}; 
const openConsultaAgenda = (id: number) => {     
    router.push(`/pages/agenda/?justica=${id}`);    
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
    router.push(`/pages/agendafinanceiro/?justica=${id}`);    
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
const openConsultaAreasJustica = (id: number) => {     
    router.push(`/pages/areasjustica/?justica=${id}`);    
};

const EditarCellAreasJustica = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaAreasJustica(props.dataItem.id)}><span title='Editar Areas Justica'><SvgIcon icon={pencilIcon} /></span></div>
        </td>
      </>
    );
}; 
const openConsultaDivisaoTribunal = (id: number) => {     
    router.push(`/pages/divisaotribunal/?justica=${id}`);    
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
const openConsultaFase = (id: number) => {     
    router.push(`/pages/fase/?justica=${id}`);    
};

const EditarCellFase = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaFase(props.dataItem.id)}><span title='Editar Fase'><SvgIcon icon={pencilIcon} /></span></div>
        </td>
      </>
    );
}; 
const openConsultaObjetos = (id: number) => {     
    router.push(`/pages/objetos/?justica=${id}`);    
};

const EditarCellObjetos = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaObjetos(props.dataItem.id)}><span title='Editar Objetos'><SvgIcon icon={pencilIcon} /></span></div>
        </td>
      </>
    );
}; 
const openConsultaPoderJudiciarioAssociado = (id: number) => {     
    router.push(`/pages/poderjudiciarioassociado/?justica=${id}`);    
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
const openConsultaProcessos = (id: number) => {     
    router.push(`/pages/processos/?justica=${id}`);    
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
const openConsultaTipoRecurso = (id: number) => {     
    router.push(`/pages/tiporecurso/?justica=${id}`);    
};

const EditarCellTipoRecurso = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaTipoRecurso(props.dataItem.id)}><span title='Editar Tipo Recurso'><SvgIcon icon={pencilIcon} /></span></div>
        </td>
      </>
    );
}; 
const openConsultaTribunal = (id: number) => {     
    router.push(`/pages/tribunal/?justica=${id}`);    
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
