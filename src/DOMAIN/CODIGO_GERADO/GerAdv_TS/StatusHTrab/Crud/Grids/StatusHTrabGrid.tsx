//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { StatusHTrabEmpty } from "../../../Models/StatusHTrab";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IStatusHTrab } from "../../Interfaces/interface.StatusHTrab";
import { StatusHTrabService } from "../../Services/StatusHTrab.service";
import { StatusHTrabApi } from "../../Apis/ApiStatusHTrab";
import { StatusHTrabGridMobileComponent } from "../GridsMobile/StatusHTrab";
import { StatusHTrabGridDesktopComponent } from "../GridsDesktop/StatusHTrab";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterStatusHTrab } from "../../Filters/StatusHTrab";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import StatusHTrabWindow from "./StatusHTrabWindow";

const StatusHTrabGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [statushtrab, setStatusHTrab] = useState<IStatusHTrab[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedStatusHTrab, setSelectedStatusHTrab] = useState<IStatusHTrab>(StatusHTrabEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new StatusHTrabApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterStatusHTrab | undefined | null>(null);

    const statushtrabService = useMemo(() => {
      return new StatusHTrabService(
          new StatusHTrabApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchStatusHTrab = async (filtro?: FilterStatusHTrab | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await statushtrabService.getList(filtro ?? {} as FilterStatusHTrab);
        setStatusHTrab(data);
      }
      else {
        const data = await statushtrabService.getAll(filtro ?? {} as FilterStatusHTrab);
        setStatusHTrab(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchStatusHTrab(currFilter);
    }, [showInc]);
  
    const handleRowClick = (statushtrab: IStatusHTrab) => {
      if (isMobile) {
        router.push(`/pages/statushtrab/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${statushtrab.id}`);
      } else {
        setSelectedStatusHTrab(statushtrab);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/statushtrab/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedStatusHTrab(StatusHTrabEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchStatusHTrab(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const statushtrab = e.dataItem;		
        setDeleteId(statushtrab.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchStatusHTrab(currFilter);
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
           <StatusHTrabGridMobileComponent data={statushtrab} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <StatusHTrabGridDesktopComponent data={statushtrab} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <StatusHTrabWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedStatusHTrab={selectedStatusHTrab}>       
        </StatusHTrabWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default StatusHTrabGrid;