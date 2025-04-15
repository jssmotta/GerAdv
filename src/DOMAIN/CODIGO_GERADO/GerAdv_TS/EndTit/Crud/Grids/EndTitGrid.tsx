//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { EndTitEmpty } from "../../../Models/EndTit";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import EndTitInc from "../Inc/EndTit";
import { IEndTit } from "../../Interfaces/interface.EndTit";
import { EndTitService } from "../../Services/EndTit.service";
import { EndTitApi } from "../../Apis/ApiEndTit";
import { EndTitGridMobileComponent } from "../GridsMobile/EndTit";
import { EndTitGridDesktopComponent } from "../GridsDesktop/EndTit";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterEndTit } from "../../Filters/EndTit";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import EndTitWindow from "./EndTitWindow";

const EndTitGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [endtit, setEndTit] = useState<IEndTit[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedEndTit, setSelectedEndTit] = useState<IEndTit>(EndTitEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new EndTitApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterEndTit | undefined | null>(null);

    const endtitService = useMemo(() => {
      return new EndTitService(
          new EndTitApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchEndTit = async (filtro?: FilterEndTit | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await endtitService.getAll(filtro ?? {} as FilterEndTit);
        setEndTit(data);
      }
      else {
        const data = await endtitService.getAll(filtro ?? {} as FilterEndTit);
        setEndTit(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchEndTit(currFilter);
    }, [showInc]);
  
    const handleRowClick = (endtit: IEndTit) => {
      if (isMobile) {
        router.push(`/pages/endtit/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${endtit.id}`);
      } else {
        setSelectedEndTit(endtit);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/endtit/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedEndTit(EndTitEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchEndTit(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const endtit = e.dataItem;		
        setDeleteId(endtit.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchEndTit(currFilter);
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
           <EndTitGridMobileComponent data={endtit} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <EndTitGridDesktopComponent data={endtit} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <EndTitWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedEndTit={selectedEndTit}>       
        </EndTitWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default EndTitGrid;