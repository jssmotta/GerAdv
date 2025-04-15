//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { OutrasPartesClienteEmpty } from "../../../Models/OutrasPartesCliente";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import OutrasPartesClienteInc from "../Inc/OutrasPartesCliente";
import { IOutrasPartesCliente } from "../../Interfaces/interface.OutrasPartesCliente";
import { OutrasPartesClienteService } from "../../Services/OutrasPartesCliente.service";
import { OutrasPartesClienteApi } from "../../Apis/ApiOutrasPartesCliente";
import { OutrasPartesClienteGridMobileComponent } from "../GridsMobile/OutrasPartesCliente";
import { OutrasPartesClienteGridDesktopComponent } from "../GridsDesktop/OutrasPartesCliente";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterOutrasPartesCliente } from "../../Filters/OutrasPartesCliente";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import OutrasPartesClienteWindow from "./OutrasPartesClienteWindow";

const OutrasPartesClienteGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [outraspartescliente, setOutrasPartesCliente] = useState<IOutrasPartesCliente[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedOutrasPartesCliente, setSelectedOutrasPartesCliente] = useState<IOutrasPartesCliente>(OutrasPartesClienteEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new OutrasPartesClienteApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterOutrasPartesCliente | undefined | null>(null);

    const outraspartesclienteService = useMemo(() => {
      return new OutrasPartesClienteService(
          new OutrasPartesClienteApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchOutrasPartesCliente = async (filtro?: FilterOutrasPartesCliente | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await outraspartesclienteService.getList(filtro ?? {} as FilterOutrasPartesCliente);
        setOutrasPartesCliente(data);
      }
      else {
        const data = await outraspartesclienteService.getAll(filtro ?? {} as FilterOutrasPartesCliente);
        setOutrasPartesCliente(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchOutrasPartesCliente(currFilter);
    }, [showInc]);
  
    const handleRowClick = (outraspartescliente: IOutrasPartesCliente) => {
      if (isMobile) {
        router.push(`/pages/outraspartescliente/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${outraspartescliente.id}`);
      } else {
        setSelectedOutrasPartesCliente(outraspartescliente);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/outraspartescliente/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedOutrasPartesCliente(OutrasPartesClienteEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchOutrasPartesCliente(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const outraspartescliente = e.dataItem;		
        setDeleteId(outraspartescliente.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchOutrasPartesCliente(currFilter);
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
           <OutrasPartesClienteGridMobileComponent data={outraspartescliente} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <OutrasPartesClienteGridDesktopComponent data={outraspartescliente} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <OutrasPartesClienteWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedOutrasPartesCliente={selectedOutrasPartesCliente}>       
        </OutrasPartesClienteWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default OutrasPartesClienteGrid;