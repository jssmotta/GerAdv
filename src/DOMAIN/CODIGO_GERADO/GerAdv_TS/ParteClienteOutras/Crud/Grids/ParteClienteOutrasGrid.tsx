//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ParteClienteOutrasEmpty } from "../../../Models/ParteClienteOutras";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IParteClienteOutras } from "../../Interfaces/interface.ParteClienteOutras";
import { ParteClienteOutrasService } from "../../Services/ParteClienteOutras.service";
import { ParteClienteOutrasApi } from "../../Apis/ApiParteClienteOutras";
import { ParteClienteOutrasGridMobileComponent } from "../GridsMobile/ParteClienteOutras";
import { ParteClienteOutrasGridDesktopComponent } from "../GridsDesktop/ParteClienteOutras";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterParteClienteOutras } from "../../Filters/ParteClienteOutras";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ParteClienteOutrasWindow from "./ParteClienteOutrasWindow";

const ParteClienteOutrasGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [parteclienteoutras, setParteClienteOutras] = useState<IParteClienteOutras[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedParteClienteOutras, setSelectedParteClienteOutras] = useState<IParteClienteOutras>(ParteClienteOutrasEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ParteClienteOutrasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterParteClienteOutras | undefined | null>(null);

    const parteclienteoutrasService = useMemo(() => {
      return new ParteClienteOutrasService(
          new ParteClienteOutrasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchParteClienteOutras = async (filtro?: FilterParteClienteOutras | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await parteclienteoutrasService.getAll(filtro ?? {} as FilterParteClienteOutras);
        setParteClienteOutras(data);
      }
      else {
        const data = await parteclienteoutrasService.getAll(filtro ?? {} as FilterParteClienteOutras);
        setParteClienteOutras(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchParteClienteOutras(currFilter);
    }, [showInc]);
  
    const handleRowClick = (parteclienteoutras: IParteClienteOutras) => {
      if (isMobile) {
        router.push(`/pages/parteclienteoutras/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${parteclienteoutras.id}`);
      } else {
        setSelectedParteClienteOutras(parteclienteoutras);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/parteclienteoutras/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedParteClienteOutras(ParteClienteOutrasEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchParteClienteOutras(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const parteclienteoutras = e.dataItem;		
        setDeleteId(parteclienteoutras.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchParteClienteOutras(currFilter);
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
           <ParteClienteOutrasGridMobileComponent data={parteclienteoutras} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ParteClienteOutrasGridDesktopComponent data={parteclienteoutras} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ParteClienteOutrasWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedParteClienteOutras={selectedParteClienteOutras}>       
        </ParteClienteOutrasWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ParteClienteOutrasGrid;