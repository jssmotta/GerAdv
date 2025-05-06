//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { GraphEmpty } from "../../../Models/Graph";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IGraph } from "../../Interfaces/interface.Graph";
import { GraphService } from "../../Services/Graph.service";
import { GraphApi } from "../../Apis/ApiGraph";
import { GraphGridMobileComponent } from "../GridsMobile/Graph";
import { GraphGridDesktopComponent } from "../GridsDesktop/Graph";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterGraph } from "../../Filters/Graph";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import GraphWindow from "./GraphWindow";

const GraphGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [graph, setGraph] = useState<IGraph[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedGraph, setSelectedGraph] = useState<IGraph>(GraphEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new GraphApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterGraph | undefined | null>(null);

    const graphService = useMemo(() => {
      return new GraphService(
          new GraphApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchGraph = async (filtro?: FilterGraph | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await graphService.getAll(filtro ?? {} as FilterGraph);
        setGraph(data);
      }
      else {
        const data = await graphService.getAll(filtro ?? {} as FilterGraph);
        setGraph(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchGraph(currFilter);
    }, [showInc]);
  
    const handleRowClick = (graph: IGraph) => {
      if (isMobile) {
        router.push(`/pages/graph/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${graph.id}`);
      } else {
        setSelectedGraph(graph);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/graph/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedGraph(GraphEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchGraph(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const graph = e.dataItem;		
        setDeleteId(graph.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchGraph(currFilter);
            } catch {
            // falta uma mensagem de erro
            } finally {
            setDeleteId(null);
                setIsModalOpen(false);
            }
        }
    };
      
    const cancelDelete = () => {
        setDeleteId(null);
        setIsModalOpen(false);
    };

    return (
      <>
            
        {isMobile ?
           <GraphGridMobileComponent data={graph} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <GraphGridDesktopComponent data={graph} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <GraphWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedGraph={selectedGraph}>       
        </GraphWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default GraphGrid;