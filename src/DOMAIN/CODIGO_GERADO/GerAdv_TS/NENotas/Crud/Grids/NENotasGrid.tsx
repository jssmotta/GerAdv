//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { NENotasEmpty } from "../../../Models/NENotas";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { INENotas } from "../../Interfaces/interface.NENotas";
import { NENotasService } from "../../Services/NENotas.service";
import { NENotasApi } from "../../Apis/ApiNENotas";
import { NENotasGridMobileComponent } from "../GridsMobile/NENotas";
import { NENotasGridDesktopComponent } from "../GridsDesktop/NENotas";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterNENotas } from "../../Filters/NENotas";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import NENotasWindow from "./NENotasWindow";

const NENotasGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [nenotas, setNENotas] = useState<INENotas[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedNENotas, setSelectedNENotas] = useState<INENotas>(NENotasEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new NENotasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterNENotas | undefined | null>(null);

    const nenotasService = useMemo(() => {
      return new NENotasService(
          new NENotasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchNENotas = async (filtro?: FilterNENotas | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await nenotasService.getList(filtro ?? {} as FilterNENotas);
        setNENotas(data);
      }
      else {
        const data = await nenotasService.getAll(filtro ?? {} as FilterNENotas);
        setNENotas(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchNENotas(currFilter);
    }, [showInc]);
  
    const handleRowClick = (nenotas: INENotas) => {
      if (isMobile) {
        router.push(`/pages/nenotas/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${nenotas.id}`);
      } else {
        setSelectedNENotas(nenotas);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/nenotas/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedNENotas(NENotasEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchNENotas(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const nenotas = e.dataItem;		
        setDeleteId(nenotas.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchNENotas(currFilter);
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
           <NENotasGridMobileComponent data={nenotas} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <NENotasGridDesktopComponent data={nenotas} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <NENotasWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedNENotas={selectedNENotas}>       
        </NENotasWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default NENotasGrid;