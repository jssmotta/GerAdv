//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { StatusBiuEmpty } from "../../../Models/StatusBiu";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IStatusBiu } from "../../Interfaces/interface.StatusBiu";
import { StatusBiuService } from "../../Services/StatusBiu.service";
import { StatusBiuApi } from "../../Apis/ApiStatusBiu";
import { StatusBiuGridMobileComponent } from "../GridsMobile/StatusBiu";
import { StatusBiuGridDesktopComponent } from "../GridsDesktop/StatusBiu";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterStatusBiu } from "../../Filters/StatusBiu";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import StatusBiuWindow from "./StatusBiuWindow";

const StatusBiuGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [statusbiu, setStatusBiu] = useState<IStatusBiu[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedStatusBiu, setSelectedStatusBiu] = useState<IStatusBiu>(StatusBiuEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new StatusBiuApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterStatusBiu | undefined | null>(null);

    const statusbiuService = useMemo(() => {
      return new StatusBiuService(
          new StatusBiuApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchStatusBiu = async (filtro?: FilterStatusBiu | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await statusbiuService.getList(filtro ?? {} as FilterStatusBiu);
        setStatusBiu(data);
      }
      else {
        const data = await statusbiuService.getAll(filtro ?? {} as FilterStatusBiu);
        setStatusBiu(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchStatusBiu(currFilter);
    }, [showInc]);
  
    const handleRowClick = (statusbiu: IStatusBiu) => {
      if (isMobile) {
        router.push(`/pages/statusbiu/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${statusbiu.id}`);
      } else {
        setSelectedStatusBiu(statusbiu);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/statusbiu/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedStatusBiu(StatusBiuEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchStatusBiu(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const statusbiu = e.dataItem;		
        setDeleteId(statusbiu.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchStatusBiu(currFilter);
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
           <StatusBiuGridMobileComponent data={statusbiu} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <StatusBiuGridDesktopComponent data={statusbiu} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <StatusBiuWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedStatusBiu={selectedStatusBiu}>       
        </StatusBiuWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default StatusBiuGrid;