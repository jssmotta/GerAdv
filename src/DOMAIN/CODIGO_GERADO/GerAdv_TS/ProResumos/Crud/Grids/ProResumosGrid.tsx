//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ProResumosEmpty } from "../../../Models/ProResumos";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IProResumos } from "../../Interfaces/interface.ProResumos";
import { ProResumosService } from "../../Services/ProResumos.service";
import { ProResumosApi } from "../../Apis/ApiProResumos";
import { ProResumosGridMobileComponent } from "../GridsMobile/ProResumos";
import { ProResumosGridDesktopComponent } from "../GridsDesktop/ProResumos";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterProResumos } from "../../Filters/ProResumos";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ProResumosWindow from "./ProResumosWindow";

const ProResumosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [proresumos, setProResumos] = useState<IProResumos[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedProResumos, setSelectedProResumos] = useState<IProResumos>(ProResumosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ProResumosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterProResumos | undefined | null>(null);

    const proresumosService = useMemo(() => {
      return new ProResumosService(
          new ProResumosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchProResumos = async (filtro?: FilterProResumos | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await proresumosService.getAll(filtro ?? {} as FilterProResumos);
        setProResumos(data);
      }
      else {
        const data = await proresumosService.getAll(filtro ?? {} as FilterProResumos);
        setProResumos(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchProResumos(currFilter);
    }, [showInc]);
  
    const handleRowClick = (proresumos: IProResumos) => {
      if (isMobile) {
        router.push(`/pages/proresumos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${proresumos.id}`);
      } else {
        setSelectedProResumos(proresumos);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/proresumos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedProResumos(ProResumosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchProResumos(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const proresumos = e.dataItem;		
        setDeleteId(proresumos.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchProResumos(currFilter);
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
           <ProResumosGridMobileComponent data={proresumos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ProResumosGridDesktopComponent data={proresumos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ProResumosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedProResumos={selectedProResumos}>       
        </ProResumosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ProResumosGrid;