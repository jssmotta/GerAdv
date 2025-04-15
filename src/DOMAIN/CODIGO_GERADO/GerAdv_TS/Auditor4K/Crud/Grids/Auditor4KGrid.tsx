//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { Auditor4KEmpty } from "../../../Models/Auditor4K";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import Auditor4KInc from "../Inc/Auditor4K";
import { IAuditor4K } from "../../Interfaces/interface.Auditor4K";
import { Auditor4KService } from "../../Services/Auditor4K.service";
import { Auditor4KApi } from "../../Apis/ApiAuditor4K";
import { Auditor4KGridMobileComponent } from "../GridsMobile/Auditor4K";
import { Auditor4KGridDesktopComponent } from "../GridsDesktop/Auditor4K";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterAuditor4K } from "../../Filters/Auditor4K";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import Auditor4KWindow from "./Auditor4KWindow";

const Auditor4KGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [auditor4k, setAuditor4K] = useState<IAuditor4K[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedAuditor4K, setSelectedAuditor4K] = useState<IAuditor4K>(Auditor4KEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new Auditor4KApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterAuditor4K | undefined | null>(null);

    const auditor4kService = useMemo(() => {
      return new Auditor4KService(
          new Auditor4KApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchAuditor4K = async (filtro?: FilterAuditor4K | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await auditor4kService.getList(filtro ?? {} as FilterAuditor4K);
        setAuditor4K(data);
      }
      else {
        const data = await auditor4kService.getAll(filtro ?? {} as FilterAuditor4K);
        setAuditor4K(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchAuditor4K(currFilter);
    }, [showInc]);
  
    const handleRowClick = (auditor4k: IAuditor4K) => {
      if (isMobile) {
        router.push(`/pages/auditor4k/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${auditor4k.id}`);
      } else {
        setSelectedAuditor4K(auditor4k);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/auditor4k/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedAuditor4K(Auditor4KEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchAuditor4K(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const auditor4k = e.dataItem;		
        setDeleteId(auditor4k.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchAuditor4K(currFilter);
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
           <Auditor4KGridMobileComponent data={auditor4k} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <Auditor4KGridDesktopComponent data={auditor4k} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <Auditor4KWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedAuditor4K={selectedAuditor4K}>       
        </Auditor4KWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default Auditor4KGrid;