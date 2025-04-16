//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ProValoresEmpty } from "../../../Models/ProValores";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import ProValoresInc from "../Inc/ProValores";
import { IProValores } from "../../Interfaces/interface.ProValores";
import { ProValoresService } from "../../Services/ProValores.service";
import { ProValoresApi } from "../../Apis/ApiProValores";
import { ProValoresGridMobileComponent } from "../GridsMobile/ProValores";
import { ProValoresGridDesktopComponent } from "../GridsDesktop/ProValores";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterProValores } from "../../Filters/ProValores";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import ProValoresWindow from "./ProValoresWindow";

const ProValoresGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [provalores, setProValores] = useState<IProValores[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedProValores, setSelectedProValores] = useState<IProValores>(ProValoresEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ProValoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterProValores | undefined | null>(null);

    const provaloresService = useMemo(() => {
      return new ProValoresService(
          new ProValoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchProValores = async (filtro?: FilterProValores | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await provaloresService.getAll(filtro ?? {} as FilterProValores);
        setProValores(data);
      }
      else {
        const data = await provaloresService.getAll(filtro ?? {} as FilterProValores);
        setProValores(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchProValores(currFilter);
    }, [showInc]);
  
    const handleRowClick = (provalores: IProValores) => {
      if (isMobile) {
        router.push(`/pages/provalores/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${provalores.id}`);
      } else {
        setSelectedProValores(provalores);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/provalores/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedProValores(ProValoresEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchProValores(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const provalores = e.dataItem;		
        setDeleteId(provalores.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchProValores(currFilter);
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
           <ProValoresGridMobileComponent data={provalores} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <ProValoresGridDesktopComponent data={provalores} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <ProValoresWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedProValores={selectedProValores}>       
        </ProValoresWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ProValoresGrid;