//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { AlertasEmpty } from "../../../Models/Alertas";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import AlertasInc from "../Inc/Alertas";
import { IAlertas } from "../../Interfaces/interface.Alertas";
import { AlertasService } from "../../Services/Alertas.service";
import { AlertasApi } from "../../Apis/ApiAlertas";
import { AlertasGridMobileComponent } from "../GridsMobile/Alertas";
import { AlertasGridDesktopComponent } from "../GridsDesktop/Alertas";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterAlertas } from "../../Filters/Alertas";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import AlertasWindow from "./AlertasWindow";

const AlertasGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [alertas, setAlertas] = useState<IAlertas[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedAlertas, setSelectedAlertas] = useState<IAlertas>(AlertasEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new AlertasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterAlertas | undefined | null>(null);

    const alertasService = useMemo(() => {
      return new AlertasService(
          new AlertasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchAlertas = async (filtro?: FilterAlertas | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await alertasService.getList(filtro ?? {} as FilterAlertas);
        setAlertas(data);
      }
      else {
        const data = await alertasService.getAll(filtro ?? {} as FilterAlertas);
        setAlertas(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchAlertas(currFilter);
    }, [showInc]);
  
    const handleRowClick = (alertas: IAlertas) => {
      if (isMobile) {
        router.push(`/pages/alertas/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${alertas.id}`);
      } else {
        setSelectedAlertas(alertas);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/alertas/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedAlertas(AlertasEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchAlertas(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const alertas = e.dataItem;		
        setDeleteId(alertas.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchAlertas(currFilter);
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
           <AlertasGridMobileComponent data={alertas} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <AlertasGridDesktopComponent data={alertas} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <AlertasWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedAlertas={selectedAlertas}>       
        </AlertasWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default AlertasGrid;