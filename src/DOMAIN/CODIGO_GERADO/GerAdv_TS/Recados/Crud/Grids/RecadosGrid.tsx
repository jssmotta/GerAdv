//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { RecadosEmpty } from "../../../Models/Recados";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import RecadosInc from "../Inc/Recados";
import { IRecados } from "../../Interfaces/interface.Recados";
import { RecadosService } from "../../Services/Recados.service";
import { RecadosApi } from "../../Apis/ApiRecados";
import { RecadosGridMobileComponent } from "../GridsMobile/Recados";
import { RecadosGridDesktopComponent } from "../GridsDesktop/Recados";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterRecados } from "../../Filters/Recados";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import RecadosWindow from "./RecadosWindow";

const RecadosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [recados, setRecados] = useState<IRecados[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedRecados, setSelectedRecados] = useState<IRecados>(RecadosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new RecadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterRecados | undefined | null>(null);

    const recadosService = useMemo(() => {
      return new RecadosService(
          new RecadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchRecados = async (filtro?: FilterRecados | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await recadosService.getAll(filtro ?? {} as FilterRecados);
        setRecados(data);
      }
      else {
        const data = await recadosService.getAll(filtro ?? {} as FilterRecados);
        setRecados(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchRecados(currFilter);
    }, [showInc]);
  
    const handleRowClick = (recados: IRecados) => {
      if (isMobile) {
        router.push(`/pages/recados/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${recados.id}`);
      } else {
        setSelectedRecados(recados);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/recados/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedRecados(RecadosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchRecados(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const recados = e.dataItem;		
        setDeleteId(recados.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchRecados(currFilter);
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
           <RecadosGridMobileComponent data={recados} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <RecadosGridDesktopComponent data={recados} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <RecadosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedRecados={selectedRecados}>       
        </RecadosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default RecadosGrid;