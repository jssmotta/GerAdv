//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ForoEmpty } from "../../../Models/Foro";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import ForoInc from "../Inc/Foro";
import { IForo } from "../../Interfaces/interface.Foro";
import { ForoService } from "../../Services/Foro.service";
import { ForoApi } from "../../Apis/ApiForo";
import { ForoGridMobileComponent } from "../GridsMobile/Foro";
import { ForoGridDesktopComponent } from "../GridsDesktop/Foro";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterForo } from "../../Filters/Foro";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import ForoWindow from "./ForoWindow";

const ForoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [foro, setForo] = useState<IForo[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedForo, setSelectedForo] = useState<IForo>(ForoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ForoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterForo | undefined | null>(null);

    const foroService = useMemo(() => {
      return new ForoService(
          new ForoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchForo = async (filtro?: FilterForo | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await foroService.getList(filtro ?? {} as FilterForo);
        setForo(data);
      }
      else {
        const data = await foroService.getAll(filtro ?? {} as FilterForo);
        setForo(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchForo(currFilter);
    }, [showInc]);
  
    const handleRowClick = (foro: IForo) => {
      if (isMobile) {
        router.push(`/pages/foro/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${foro.id}`);
      } else {
        setSelectedForo(foro);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/foro/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedForo(ForoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchForo(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const foro = e.dataItem;		
        setDeleteId(foro.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchForo(currFilter);
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
        <AppGridToolbar onAdd={handleAdd} />    

        {isMobile ?
           <ForoGridMobileComponent data={foro} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <ForoGridDesktopComponent data={foro} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <ForoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedForo={selectedForo}>       
        </ForoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ForoGrid;