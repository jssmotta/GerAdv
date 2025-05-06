//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { GUTPeriodicidadeStatusEmpty } from "../../../Models/GUTPeriodicidadeStatus";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IGUTPeriodicidadeStatus } from "../../Interfaces/interface.GUTPeriodicidadeStatus";
import { GUTPeriodicidadeStatusService } from "../../Services/GUTPeriodicidadeStatus.service";
import { GUTPeriodicidadeStatusApi } from "../../Apis/ApiGUTPeriodicidadeStatus";
import { GUTPeriodicidadeStatusGridMobileComponent } from "../GridsMobile/GUTPeriodicidadeStatus";
import { GUTPeriodicidadeStatusGridDesktopComponent } from "../GridsDesktop/GUTPeriodicidadeStatus";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterGUTPeriodicidadeStatus } from "../../Filters/GUTPeriodicidadeStatus";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import GUTPeriodicidadeStatusWindow from "./GUTPeriodicidadeStatusWindow";

const GUTPeriodicidadeStatusGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [gutperiodicidadestatus, setGUTPeriodicidadeStatus] = useState<IGUTPeriodicidadeStatus[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedGUTPeriodicidadeStatus, setSelectedGUTPeriodicidadeStatus] = useState<IGUTPeriodicidadeStatus>(GUTPeriodicidadeStatusEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new GUTPeriodicidadeStatusApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterGUTPeriodicidadeStatus | undefined | null>(null);

    const gutperiodicidadestatusService = useMemo(() => {
      return new GUTPeriodicidadeStatusService(
          new GUTPeriodicidadeStatusApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchGUTPeriodicidadeStatus = async (filtro?: FilterGUTPeriodicidadeStatus | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await gutperiodicidadestatusService.getAll(filtro ?? {} as FilterGUTPeriodicidadeStatus);
        setGUTPeriodicidadeStatus(data);
      }
      else {
        const data = await gutperiodicidadestatusService.getAll(filtro ?? {} as FilterGUTPeriodicidadeStatus);
        setGUTPeriodicidadeStatus(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchGUTPeriodicidadeStatus(currFilter);
    }, [showInc]);
  
    const handleRowClick = (gutperiodicidadestatus: IGUTPeriodicidadeStatus) => {
      if (isMobile) {
        router.push(`/pages/gutperiodicidadestatus/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${gutperiodicidadestatus.id}`);
      } else {
        setSelectedGUTPeriodicidadeStatus(gutperiodicidadestatus);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/gutperiodicidadestatus/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedGUTPeriodicidadeStatus(GUTPeriodicidadeStatusEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchGUTPeriodicidadeStatus(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const gutperiodicidadestatus = e.dataItem;		
        setDeleteId(gutperiodicidadestatus.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchGUTPeriodicidadeStatus(currFilter);
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
           <GUTPeriodicidadeStatusGridMobileComponent data={gutperiodicidadestatus} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <GUTPeriodicidadeStatusGridDesktopComponent data={gutperiodicidadestatus} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <GUTPeriodicidadeStatusWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedGUTPeriodicidadeStatus={selectedGUTPeriodicidadeStatus}>       
        </GUTPeriodicidadeStatusWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default GUTPeriodicidadeStatusGrid;