//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { StatusAndamentoEmpty } from "../../../Models/StatusAndamento";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import StatusAndamentoInc from "../Inc/StatusAndamento";
import { IStatusAndamento } from "../../Interfaces/interface.StatusAndamento";
import { StatusAndamentoService } from "../../Services/StatusAndamento.service";
import { StatusAndamentoApi } from "../../Apis/ApiStatusAndamento";
import { StatusAndamentoGridMobileComponent } from "../GridsMobile/StatusAndamento";
import { StatusAndamentoGridDesktopComponent } from "../GridsDesktop/StatusAndamento";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterStatusAndamento } from "../../Filters/StatusAndamento";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import StatusAndamentoWindow from "./StatusAndamentoWindow";

const StatusAndamentoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [statusandamento, setStatusAndamento] = useState<IStatusAndamento[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedStatusAndamento, setSelectedStatusAndamento] = useState<IStatusAndamento>(StatusAndamentoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new StatusAndamentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterStatusAndamento | undefined | null>(null);

    const statusandamentoService = useMemo(() => {
      return new StatusAndamentoService(
          new StatusAndamentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchStatusAndamento = async (filtro?: FilterStatusAndamento | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await statusandamentoService.getList(filtro ?? {} as FilterStatusAndamento);
        setStatusAndamento(data);
      }
      else {
        const data = await statusandamentoService.getAll(filtro ?? {} as FilterStatusAndamento);
        setStatusAndamento(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchStatusAndamento(currFilter);
    }, [showInc]);
  
    const handleRowClick = (statusandamento: IStatusAndamento) => {
      if (isMobile) {
        router.push(`/pages/statusandamento/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${statusandamento.id}`);
      } else {
        setSelectedStatusAndamento(statusandamento);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/statusandamento/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedStatusAndamento(StatusAndamentoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchStatusAndamento(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const statusandamento = e.dataItem;		
        setDeleteId(statusandamento.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchStatusAndamento(currFilter);
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
           <StatusAndamentoGridMobileComponent data={statusandamento} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <StatusAndamentoGridDesktopComponent data={statusandamento} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <StatusAndamentoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedStatusAndamento={selectedStatusAndamento}>       
        </StatusAndamentoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default StatusAndamentoGrid;