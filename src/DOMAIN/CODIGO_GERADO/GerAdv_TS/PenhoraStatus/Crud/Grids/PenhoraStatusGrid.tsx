//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { PenhoraStatusEmpty } from "../../../Models/PenhoraStatus";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IPenhoraStatus } from "../../Interfaces/interface.PenhoraStatus";
import { PenhoraStatusService } from "../../Services/PenhoraStatus.service";
import { PenhoraStatusApi } from "../../Apis/ApiPenhoraStatus";
import { PenhoraStatusGridMobileComponent } from "../GridsMobile/PenhoraStatus";
import { PenhoraStatusGridDesktopComponent } from "../GridsDesktop/PenhoraStatus";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterPenhoraStatus } from "../../Filters/PenhoraStatus";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import PenhoraStatusWindow from "./PenhoraStatusWindow";

const PenhoraStatusGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [penhorastatus, setPenhoraStatus] = useState<IPenhoraStatus[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedPenhoraStatus, setSelectedPenhoraStatus] = useState<IPenhoraStatus>(PenhoraStatusEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new PenhoraStatusApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterPenhoraStatus | undefined | null>(null);

    const penhorastatusService = useMemo(() => {
      return new PenhoraStatusService(
          new PenhoraStatusApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchPenhoraStatus = async (filtro?: FilterPenhoraStatus | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await penhorastatusService.getList(filtro ?? {} as FilterPenhoraStatus);
        setPenhoraStatus(data);
      }
      else {
        const data = await penhorastatusService.getAll(filtro ?? {} as FilterPenhoraStatus);
        setPenhoraStatus(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchPenhoraStatus(currFilter);
    }, [showInc]);
  
    const handleRowClick = (penhorastatus: IPenhoraStatus) => {
      if (isMobile) {
        router.push(`/pages/penhorastatus/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${penhorastatus.id}`);
      } else {
        setSelectedPenhoraStatus(penhorastatus);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/penhorastatus/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedPenhoraStatus(PenhoraStatusEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchPenhoraStatus(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const penhorastatus = e.dataItem;		
        setDeleteId(penhorastatus.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchPenhoraStatus(currFilter);
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
           <PenhoraStatusGridMobileComponent data={penhorastatus} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <PenhoraStatusGridDesktopComponent data={penhorastatus} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <PenhoraStatusWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedPenhoraStatus={selectedPenhoraStatus}>       
        </PenhoraStatusWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default PenhoraStatusGrid;