//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { PrepostosEmpty } from "../../../Models/Prepostos";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IPrepostos } from "../../Interfaces/interface.Prepostos";
import { PrepostosService } from "../../Services/Prepostos.service";
import { PrepostosApi } from "../../Apis/ApiPrepostos";
import { PrepostosGridMobileComponent } from "../GridsMobile/Prepostos";
import { PrepostosGridDesktopComponent } from "../GridsDesktop/Prepostos";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterPrepostos } from "../../Filters/Prepostos";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import PrepostosWindow from "./PrepostosWindow";

const PrepostosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [prepostos, setPrepostos] = useState<IPrepostos[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedPrepostos, setSelectedPrepostos] = useState<IPrepostos>(PrepostosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new PrepostosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterPrepostos | undefined | null>(null);

    const prepostosService = useMemo(() => {
      return new PrepostosService(
          new PrepostosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchPrepostos = async (filtro?: FilterPrepostos | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await prepostosService.getList(filtro ?? {} as FilterPrepostos);
        setPrepostos(data);
      }
      else {
        const data = await prepostosService.getAll(filtro ?? {} as FilterPrepostos);
        setPrepostos(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchPrepostos(currFilter);
    }, [showInc]);
  
    const handleRowClick = (prepostos: IPrepostos) => {
      if (isMobile) {
        router.push(`/pages/prepostos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${prepostos.id}`);
      } else {
        setSelectedPrepostos(prepostos);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/prepostos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedPrepostos(PrepostosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchPrepostos(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const prepostos = e.dataItem;		
        setDeleteId(prepostos.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchPrepostos(currFilter);
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
           <PrepostosGridMobileComponent data={prepostos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <PrepostosGridDesktopComponent data={prepostos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <PrepostosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedPrepostos={selectedPrepostos}>       
        </PrepostosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default PrepostosGrid;