import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import ProDespesasInc from "../Inc/ProDespesas";
import { IProDespesas } from "../../Interfaces/interface.ProDespesas";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ProDespesasEmpty } from "@/app/GerAdv_TS/Models/ProDespesas";
import { useWindow } from "@/app/hooks/useWindows";

interface ProDespesasWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedProDespesas?: IProDespesas;
    onSuccess: () => void;
    onError: () => void;
}

const ProDespesasWindow: React.FC<ProDespesasWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedProDespesas,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/prodespesas/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedProDespesas?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedProDespesas]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={585}
                    newWidth={1440}
                    id={(selectedProDespesas?.id ?? 0).toString()}
                >
                    <ProDespesasInc
                        id={selectedProDespesas?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowProDespesas: React.FC<ProDespesasWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ProDespesasWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedProDespesas={ProDespesasEmpty()}>
        </ProDespesasWindow>
    )
};

export default ProDespesasWindow;