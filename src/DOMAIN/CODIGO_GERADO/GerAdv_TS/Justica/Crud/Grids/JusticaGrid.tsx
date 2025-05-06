//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { JusticaEmpty } from "../../../Models/Justica";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IJustica } from "../../Interfaces/interface.Justica";
import { JusticaService } from "../../Services/Justica.service";
import { JusticaApi } from "../../Apis/ApiJustica";
import { JusticaGridMobileComponent } from "../GridsMobile/Justica";
import { JusticaGridDesktopComponent } from "../GridsDesktop/Justica";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterJustica } from "../../Filters/Justica";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import JusticaWindow from "./JusticaWindow";

const JusticaGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [justica, setJustica] = useState<IJustica[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedJustica, setSelectedJustica] = useState<IJustica>(JusticaEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new JusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterJustica | undefined | null>(null);

    const justicaService = useMemo(() => {
      return new JusticaService(
          new JusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchJustica = async (filtro?: FilterJustica | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await justicaService.getList(filtro ?? {} as FilterJustica);
        setJustica(data);
      }
      else {
        const data = await justicaService.getAll(filtro ?? {} as FilterJustica);
        setJustica(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchJustica(currFilter);
    }, [showInc]);
  
    const handleRowClick = (justica: IJustica) => {
      if (isMobile) {
        router.push(`/pages/justica/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${justica.id}`);
      } else {
        setSelectedJustica(justica);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/justica/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedJustica(JusticaEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchJustica(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const justica = e.dataItem;		
        setDeleteId(justica.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchJustica(currFilter);
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
           <JusticaGridMobileComponent data={justica} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <JusticaGridDesktopComponent data={justica} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <JusticaWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedJustica={selectedJustica}>       
        </JusticaWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default JusticaGrid;