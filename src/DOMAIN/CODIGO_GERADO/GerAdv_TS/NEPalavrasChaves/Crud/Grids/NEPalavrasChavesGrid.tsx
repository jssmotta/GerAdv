//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { NEPalavrasChavesEmpty } from "../../../Models/NEPalavrasChaves";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import NEPalavrasChavesInc from "../Inc/NEPalavrasChaves";
import { INEPalavrasChaves } from "../../Interfaces/interface.NEPalavrasChaves";
import { NEPalavrasChavesService } from "../../Services/NEPalavrasChaves.service";
import { NEPalavrasChavesApi } from "../../Apis/ApiNEPalavrasChaves";
import { NEPalavrasChavesGridMobileComponent } from "../GridsMobile/NEPalavrasChaves";
import { NEPalavrasChavesGridDesktopComponent } from "../GridsDesktop/NEPalavrasChaves";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterNEPalavrasChaves } from "../../Filters/NEPalavrasChaves";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import NEPalavrasChavesWindow from "./NEPalavrasChavesWindow";

const NEPalavrasChavesGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [nepalavraschaves, setNEPalavrasChaves] = useState<INEPalavrasChaves[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedNEPalavrasChaves, setSelectedNEPalavrasChaves] = useState<INEPalavrasChaves>(NEPalavrasChavesEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new NEPalavrasChavesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterNEPalavrasChaves | undefined | null>(null);

    const nepalavraschavesService = useMemo(() => {
      return new NEPalavrasChavesService(
          new NEPalavrasChavesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchNEPalavrasChaves = async (filtro?: FilterNEPalavrasChaves | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await nepalavraschavesService.getList(filtro ?? {} as FilterNEPalavrasChaves);
        setNEPalavrasChaves(data);
      }
      else {
        const data = await nepalavraschavesService.getAll(filtro ?? {} as FilterNEPalavrasChaves);
        setNEPalavrasChaves(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchNEPalavrasChaves(currFilter);
    }, [showInc]);
  
    const handleRowClick = (nepalavraschaves: INEPalavrasChaves) => {
      if (isMobile) {
        router.push(`/pages/nepalavraschaves/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${nepalavraschaves.id}`);
      } else {
        setSelectedNEPalavrasChaves(nepalavraschaves);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/nepalavraschaves/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedNEPalavrasChaves(NEPalavrasChavesEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchNEPalavrasChaves(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const nepalavraschaves = e.dataItem;		
        setDeleteId(nepalavraschaves.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchNEPalavrasChaves(currFilter);
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
           <NEPalavrasChavesGridMobileComponent data={nepalavraschaves} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <NEPalavrasChavesGridDesktopComponent data={nepalavraschaves} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <NEPalavrasChavesWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedNEPalavrasChaves={selectedNEPalavrasChaves}>       
        </NEPalavrasChavesWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default NEPalavrasChavesGrid;