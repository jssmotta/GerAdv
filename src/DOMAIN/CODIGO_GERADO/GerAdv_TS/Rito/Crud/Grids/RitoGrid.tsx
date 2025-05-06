//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { RitoEmpty } from "../../../Models/Rito";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IRito } from "../../Interfaces/interface.Rito";
import { RitoService } from "../../Services/Rito.service";
import { RitoApi } from "../../Apis/ApiRito";
import { RitoGridMobileComponent } from "../GridsMobile/Rito";
import { RitoGridDesktopComponent } from "../GridsDesktop/Rito";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterRito } from "../../Filters/Rito";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import RitoWindow from "./RitoWindow";

const RitoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [rito, setRito] = useState<IRito[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedRito, setSelectedRito] = useState<IRito>(RitoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new RitoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterRito | undefined | null>(null);

    const ritoService = useMemo(() => {
      return new RitoService(
          new RitoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchRito = async (filtro?: FilterRito | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await ritoService.getList(filtro ?? {} as FilterRito);
        setRito(data);
      }
      else {
        const data = await ritoService.getAll(filtro ?? {} as FilterRito);
        setRito(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchRito(currFilter);
    }, [showInc]);
  
    const handleRowClick = (rito: IRito) => {
      if (isMobile) {
        router.push(`/pages/rito/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${rito.id}`);
      } else {
        setSelectedRito(rito);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/rito/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedRito(RitoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchRito(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const rito = e.dataItem;		
        setDeleteId(rito.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchRito(currFilter);
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
           <RitoGridMobileComponent data={rito} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <RitoGridDesktopComponent data={rito} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <RitoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedRito={selectedRito}>       
        </RitoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default RitoGrid;