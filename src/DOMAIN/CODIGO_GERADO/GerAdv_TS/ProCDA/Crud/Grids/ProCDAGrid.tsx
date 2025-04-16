//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ProCDAEmpty } from "../../../Models/ProCDA";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import ProCDAInc from "../Inc/ProCDA";
import { IProCDA } from "../../Interfaces/interface.ProCDA";
import { ProCDAService } from "../../Services/ProCDA.service";
import { ProCDAApi } from "../../Apis/ApiProCDA";
import { ProCDAGridMobileComponent } from "../GridsMobile/ProCDA";
import { ProCDAGridDesktopComponent } from "../GridsDesktop/ProCDA";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterProCDA } from "../../Filters/ProCDA";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import ProCDAWindow from "./ProCDAWindow";

const ProCDAGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [procda, setProCDA] = useState<IProCDA[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedProCDA, setSelectedProCDA] = useState<IProCDA>(ProCDAEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ProCDAApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterProCDA | undefined | null>(null);

    const procdaService = useMemo(() => {
      return new ProCDAService(
          new ProCDAApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchProCDA = async (filtro?: FilterProCDA | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await procdaService.getList(filtro ?? {} as FilterProCDA);
        setProCDA(data);
      }
      else {
        const data = await procdaService.getAll(filtro ?? {} as FilterProCDA);
        setProCDA(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchProCDA(currFilter);
    }, [showInc]);
  
    const handleRowClick = (procda: IProCDA) => {
      if (isMobile) {
        router.push(`/pages/procda/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${procda.id}`);
      } else {
        setSelectedProCDA(procda);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/procda/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedProCDA(ProCDAEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchProCDA(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const procda = e.dataItem;		
        setDeleteId(procda.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchProCDA(currFilter);
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
           <ProCDAGridMobileComponent data={procda} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <ProCDAGridDesktopComponent data={procda} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <ProCDAWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedProCDA={selectedProCDA}>       
        </ProCDAWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ProCDAGrid;