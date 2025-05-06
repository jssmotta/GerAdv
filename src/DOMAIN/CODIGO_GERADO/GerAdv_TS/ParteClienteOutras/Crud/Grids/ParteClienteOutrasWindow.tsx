import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import ParteClienteOutrasInc from "../Inc/ParteClienteOutras";
import { IParteClienteOutras } from "../../Interfaces/interface.ParteClienteOutras";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ParteClienteOutrasEmpty } from "@/app/GerAdv_TS/Models/ParteClienteOutras";
import { useWindow } from "@/app/hooks/useWindows";

interface ParteClienteOutrasWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedParteClienteOutras?: IParteClienteOutras;
    onSuccess: () => void;
    onError: () => void;
}

const ParteClienteOutrasWindow: React.FC<ParteClienteOutrasWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedParteClienteOutras,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/parteclienteoutras/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedParteClienteOutras?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedParteClienteOutras]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedParteClienteOutras?.id ?? 0).toString()}
                >
                    <ParteClienteOutrasInc
                        id={selectedParteClienteOutras?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowParteClienteOutras: React.FC<ParteClienteOutrasWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ParteClienteOutrasWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedParteClienteOutras={ParteClienteOutrasEmpty()}>
        </ParteClienteOutrasWindow>
    )
};

export default ParteClienteOutrasWindow;