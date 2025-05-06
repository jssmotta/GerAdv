//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ClientesEmpty } from "../../../Models/Clientes";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IClientes } from "../../Interfaces/interface.Clientes";
import { ClientesService } from "../../Services/Clientes.service";
import { ClientesApi } from "../../Apis/ApiClientes";
import { ClientesGridMobileComponent } from "../GridsMobile/Clientes";
import { ClientesGridDesktopComponent } from "../GridsDesktop/Clientes";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterClientes } from "../../Filters/Clientes";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ClientesWindow from "./ClientesWindow";

const ClientesGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [clientes, setClientes] = useState<IClientes[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedClientes, setSelectedClientes] = useState<IClientes>(ClientesEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterClientes | undefined | null>(null);

    const clientesService = useMemo(() => {
      return new ClientesService(
          new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchClientes = async (filtro?: FilterClientes | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await clientesService.getList(filtro ?? {} as FilterClientes);
        setClientes(data);
      }
      else {
        const data = await clientesService.getAll(filtro ?? {} as FilterClientes);
        setClientes(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchClientes(currFilter);
    }, [showInc]);
  
    const handleRowClick = (clientes: IClientes) => {
      if (isMobile) {
        router.push(`/pages/clientes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${clientes.id}`);
      } else {
        setSelectedClientes(clientes);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/clientes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedClientes(ClientesEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchClientes(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const clientes = e.dataItem;		
        setDeleteId(clientes.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchClientes(currFilter);
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
           <ClientesGridMobileComponent data={clientes} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ClientesGridDesktopComponent data={clientes} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ClientesWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedClientes={selectedClientes}>       
        </ClientesWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ClientesGrid;