//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { AlertasEnviadosEmpty } from "../../../Models/AlertasEnviados";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IAlertasEnviados } from "../../Interfaces/interface.AlertasEnviados";
import { AlertasEnviadosService } from "../../Services/AlertasEnviados.service";
import { AlertasEnviadosApi } from "../../Apis/ApiAlertasEnviados";
import { AlertasEnviadosGridMobileComponent } from "../GridsMobile/AlertasEnviados";
import { AlertasEnviadosGridDesktopComponent } from "../GridsDesktop/AlertasEnviados";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterAlertasEnviados } from "../../Filters/AlertasEnviados";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import AlertasEnviadosWindow from "./AlertasEnviadosWindow";

const AlertasEnviadosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [alertasenviados, setAlertasEnviados] = useState<IAlertasEnviados[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedAlertasEnviados, setSelectedAlertasEnviados] = useState<IAlertasEnviados>(AlertasEnviadosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new AlertasEnviadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterAlertasEnviados | undefined | null>(null);

    const alertasenviadosService = useMemo(() => {
      return new AlertasEnviadosService(
          new AlertasEnviadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchAlertasEnviados = async (filtro?: FilterAlertasEnviados | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await alertasenviadosService.getAll(filtro ?? {} as FilterAlertasEnviados);
        setAlertasEnviados(data);
      }
      else {
        const data = await alertasenviadosService.getAll(filtro ?? {} as FilterAlertasEnviados);
        setAlertasEnviados(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchAlertasEnviados(currFilter);
    }, [showInc]);
  
    const handleRowClick = (alertasenviados: IAlertasEnviados) => {
      if (isMobile) {
        router.push(`/pages/alertasenviados/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${alertasenviados.id}`);
      } else {
        setSelectedAlertasEnviados(alertasenviados);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/alertasenviados/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedAlertasEnviados(AlertasEnviadosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchAlertasEnviados(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const alertasenviados = e.dataItem;		
        setDeleteId(alertasenviados.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchAlertasEnviados(currFilter);
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
           <AlertasEnviadosGridMobileComponent data={alertasenviados} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <AlertasEnviadosGridDesktopComponent data={alertasenviados} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <AlertasEnviadosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedAlertasEnviados={selectedAlertasEnviados}>       
        </AlertasEnviadosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default AlertasEnviadosGrid;