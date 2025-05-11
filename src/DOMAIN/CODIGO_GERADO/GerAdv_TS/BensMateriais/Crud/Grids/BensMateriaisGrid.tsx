//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { BensMateriaisEmpty } from "../../../Models/BensMateriais";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IBensMateriais } from "../../Interfaces/interface.BensMateriais";
import { BensMateriaisService } from "../../Services/BensMateriais.service";
import { BensMateriaisApi } from "../../Apis/ApiBensMateriais";
import { BensMateriaisGridMobileComponent } from "../GridsMobile/BensMateriais";
import { BensMateriaisGridDesktopComponent } from "../GridsDesktop/BensMateriais";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterBensMateriais } from "../../Filters/BensMateriais";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import BensMateriaisWindow from "./BensMateriaisWindow";

const BensMateriaisGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [bensmateriais, setBensMateriais] = useState<IBensMateriais[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedBensMateriais, setSelectedBensMateriais] = useState<IBensMateriais>(BensMateriaisEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new BensMateriaisApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterBensMateriais | undefined | null>(null);

    const bensmateriaisService = useMemo(() => {
      return new BensMateriaisService(
          new BensMateriaisApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchBensMateriais = async (filtro?: FilterBensMateriais | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await bensmateriaisService.getList(filtro ?? {} as FilterBensMateriais);
        setBensMateriais(data);
      }
      else {
        const data = await bensmateriaisService.getAll(filtro ?? {} as FilterBensMateriais);
        setBensMateriais(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchBensMateriais(currFilter);
    }, [showInc]);
  
    const handleRowClick = (bensmateriais: IBensMateriais) => {
      if (isMobile) {
        router.push(`/pages/bensmateriais/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${bensmateriais.id}`);
      } else {
        setSelectedBensMateriais(bensmateriais);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/bensmateriais/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedBensMateriais(BensMateriaisEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchBensMateriais(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const bensmateriais = e.dataItem;		
        setDeleteId(bensmateriais.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchBensMateriais(currFilter);
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
           <BensMateriaisGridMobileComponent data={bensmateriais} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <BensMateriaisGridDesktopComponent data={bensmateriais} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <BensMateriaisWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedBensMateriais={selectedBensMateriais}>       
        </BensMateriaisWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default BensMateriaisGrid;