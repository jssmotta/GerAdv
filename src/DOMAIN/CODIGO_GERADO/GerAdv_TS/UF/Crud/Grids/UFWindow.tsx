import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import UFInc from "../Inc/UF";
import { IUF } from "../../Interfaces/interface.UF";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { UFEmpty } from "@/app/GerAdv_TS/Models/UF";
import { useWindow } from "@/app/hooks/useWindows";

interface UFWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedUF?: IUF;
    onSuccess: () => void;
    onError: () => void;
}

const UFWindow: React.FC<UFWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedUF,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/uf/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedUF?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedUF]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedUF?.id ?? 0).toString()}
                >
                    <UFInc
                        id={selectedUF?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowUF: React.FC<UFWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <UFWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedUF={UFEmpty()}>
        </UFWindow>
    )
};

export default UFWindow;