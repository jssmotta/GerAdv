//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ContratosEmpty } from "../../../Models/Contratos";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IContratos } from "../../Interfaces/interface.Contratos";
import { ContratosService } from "../../Services/Contratos.service";
import { ContratosApi } from "../../Apis/ApiContratos";
import { ContratosGridMobileComponent } from "../GridsMobile/Contratos";
import { ContratosGridDesktopComponent } from "../GridsDesktop/Contratos";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterContratos } from "../../Filters/Contratos";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ContratosWindow from "./ContratosWindow";

const ContratosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [contratos, setContratos] = useState<IContratos[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedContratos, setSelectedContratos] = useState<IContratos>(ContratosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ContratosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterContratos | undefined | null>(null);

    const contratosService = useMemo(() => {
      return new ContratosService(
          new ContratosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchContratos = async (filtro?: FilterContratos | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await contratosService.getAll(filtro ?? {} as FilterContratos);
        setContratos(data);
      }
      else {
        const data = await contratosService.getAll(filtro ?? {} as FilterContratos);
        setContratos(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchContratos(currFilter);
    }, [showInc]);
  
    const handleRowClick = (contratos: IContratos) => {
      if (isMobile) {
        router.push(`/pages/contratos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${contratos.id}`);
      } else {
        setSelectedContratos(contratos);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/contratos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedContratos(ContratosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchContratos(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const contratos = e.dataItem;		
        setDeleteId(contratos.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchContratos(currFilter);
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
           <ContratosGridMobileComponent data={contratos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ContratosGridDesktopComponent data={contratos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ContratosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedContratos={selectedContratos}>       
        </ContratosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ContratosGrid;