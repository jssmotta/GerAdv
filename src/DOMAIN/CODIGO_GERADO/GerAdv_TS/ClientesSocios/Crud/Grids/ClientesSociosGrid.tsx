//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ClientesSociosEmpty } from "../../../Models/ClientesSocios";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import ClientesSociosInc from "../Inc/ClientesSocios";
import { IClientesSocios } from "../../Interfaces/interface.ClientesSocios";
import { ClientesSociosService } from "../../Services/ClientesSocios.service";
import { ClientesSociosApi } from "../../Apis/ApiClientesSocios";
import { ClientesSociosGridMobileComponent } from "../GridsMobile/ClientesSocios";
import { ClientesSociosGridDesktopComponent } from "../GridsDesktop/ClientesSocios";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterClientesSocios } from "../../Filters/ClientesSocios";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import ClientesSociosWindow from "./ClientesSociosWindow";

const ClientesSociosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [clientessocios, setClientesSocios] = useState<IClientesSocios[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedClientesSocios, setSelectedClientesSocios] = useState<IClientesSocios>(ClientesSociosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ClientesSociosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterClientesSocios | undefined | null>(null);

    const clientessociosService = useMemo(() => {
      return new ClientesSociosService(
          new ClientesSociosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchClientesSocios = async (filtro?: FilterClientesSocios | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await clientessociosService.getList(filtro ?? {} as FilterClientesSocios);
        setClientesSocios(data);
      }
      else {
        const data = await clientessociosService.getAll(filtro ?? {} as FilterClientesSocios);
        setClientesSocios(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchClientesSocios(currFilter);
    }, [showInc]);
  
    const handleRowClick = (clientessocios: IClientesSocios) => {
      if (isMobile) {
        router.push(`/pages/clientessocios/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${clientessocios.id}`);
      } else {
        setSelectedClientesSocios(clientessocios);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/clientessocios/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedClientesSocios(ClientesSociosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchClientesSocios(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const clientessocios = e.dataItem;		
        setDeleteId(clientessocios.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchClientesSocios(currFilter);
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
           <ClientesSociosGridMobileComponent data={clientessocios} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <ClientesSociosGridDesktopComponent data={clientessocios} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <ClientesSociosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedClientesSocios={selectedClientesSocios}>       
        </ClientesSociosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ClientesSociosGrid;