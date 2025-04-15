//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ProDespesasEmpty } from "../../../Models/ProDespesas";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import ProDespesasInc from "../Inc/ProDespesas";
import { IProDespesas } from "../../Interfaces/interface.ProDespesas";
import { ProDespesasService } from "../../Services/ProDespesas.service";
import { ProDespesasApi } from "../../Apis/ApiProDespesas";
import { ProDespesasGridMobileComponent } from "../GridsMobile/ProDespesas";
import { ProDespesasGridDesktopComponent } from "../GridsDesktop/ProDespesas";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterProDespesas } from "../../Filters/ProDespesas";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import ProDespesasWindow from "./ProDespesasWindow";

const ProDespesasGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [prodespesas, setProDespesas] = useState<IProDespesas[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedProDespesas, setSelectedProDespesas] = useState<IProDespesas>(ProDespesasEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ProDespesasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterProDespesas | undefined | null>(null);

    const prodespesasService = useMemo(() => {
      return new ProDespesasService(
          new ProDespesasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchProDespesas = async (filtro?: FilterProDespesas | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await prodespesasService.getAll(filtro ?? {} as FilterProDespesas);
        setProDespesas(data);
      }
      else {
        const data = await prodespesasService.getAll(filtro ?? {} as FilterProDespesas);
        setProDespesas(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchProDespesas(currFilter);
    }, [showInc]);
  
    const handleRowClick = (prodespesas: IProDespesas) => {
      if (isMobile) {
        router.push(`/pages/prodespesas/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${prodespesas.id}`);
      } else {
        setSelectedProDespesas(prodespesas);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/prodespesas/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedProDespesas(ProDespesasEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchProDespesas(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const prodespesas = e.dataItem;		
        setDeleteId(prodespesas.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchProDespesas(currFilter);
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
           <ProDespesasGridMobileComponent data={prodespesas} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <ProDespesasGridDesktopComponent data={prodespesas} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <ProDespesasWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedProDespesas={selectedProDespesas}>       
        </ProDespesasWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ProDespesasGrid;