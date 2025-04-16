//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ProSucumbenciaEmpty } from "../../../Models/ProSucumbencia";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import ProSucumbenciaInc from "../Inc/ProSucumbencia";
import { IProSucumbencia } from "../../Interfaces/interface.ProSucumbencia";
import { ProSucumbenciaService } from "../../Services/ProSucumbencia.service";
import { ProSucumbenciaApi } from "../../Apis/ApiProSucumbencia";
import { ProSucumbenciaGridMobileComponent } from "../GridsMobile/ProSucumbencia";
import { ProSucumbenciaGridDesktopComponent } from "../GridsDesktop/ProSucumbencia";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterProSucumbencia } from "../../Filters/ProSucumbencia";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import ProSucumbenciaWindow from "./ProSucumbenciaWindow";

const ProSucumbenciaGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [prosucumbencia, setProSucumbencia] = useState<IProSucumbencia[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedProSucumbencia, setSelectedProSucumbencia] = useState<IProSucumbencia>(ProSucumbenciaEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ProSucumbenciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterProSucumbencia | undefined | null>(null);

    const prosucumbenciaService = useMemo(() => {
      return new ProSucumbenciaService(
          new ProSucumbenciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchProSucumbencia = async (filtro?: FilterProSucumbencia | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await prosucumbenciaService.getList(filtro ?? {} as FilterProSucumbencia);
        setProSucumbencia(data);
      }
      else {
        const data = await prosucumbenciaService.getAll(filtro ?? {} as FilterProSucumbencia);
        setProSucumbencia(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchProSucumbencia(currFilter);
    }, [showInc]);
  
    const handleRowClick = (prosucumbencia: IProSucumbencia) => {
      if (isMobile) {
        router.push(`/pages/prosucumbencia/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${prosucumbencia.id}`);
      } else {
        setSelectedProSucumbencia(prosucumbencia);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/prosucumbencia/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedProSucumbencia(ProSucumbenciaEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchProSucumbencia(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const prosucumbencia = e.dataItem;		
        setDeleteId(prosucumbencia.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchProSucumbencia(currFilter);
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
           <ProSucumbenciaGridMobileComponent data={prosucumbencia} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <ProSucumbenciaGridDesktopComponent data={prosucumbencia} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <ProSucumbenciaWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedProSucumbencia={selectedProSucumbencia}>       
        </ProSucumbenciaWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ProSucumbenciaGrid;