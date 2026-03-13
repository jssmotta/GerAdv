'use client';
export interface MenuType {
  id: number;
  text: string;
  items?: MenuType[];
}

export const transformMenuTypeToTelerikFormat = (
  handleClick: any,
  menu: MenuType[] | MenuType | null | undefined | any,
  isSubItem: boolean = false
): any[] => {
    const today = new Date();
    today.setHours(0, 0, 0, 0);

    // Defensive: if menu is null/undefined, return empty array
    if (!menu) {
      return [];
    }

    // If a single MenuType object was passed, convert to array
    if (!Array.isArray(menu)) {
      // If it's an object that has an `items` array, operate on that
      if ((menu as any).items && Array.isArray((menu as any).items)) {
        return transformMenuTypeToTelerikFormat(handleClick, (menu as any).items, isSubItem);
      }

      // If it's an object map, try to use its values
      if (typeof menu === 'object') {
        const values = Object.values(menu);
        // Flatten possible nested arrays/objects into a single array of MenuType
        const flattened: MenuType[] = [];
        values.forEach((v) => {
          if (Array.isArray(v)) {
            flattened.push(...v);
          } else if (v) {
            flattened.push(v as MenuType);
          }
        });

        if (flattened.length === 0) {
          return [];
        }

        // Recurse with a proper array
        return transformMenuTypeToTelerikFormat(handleClick, flattened, isSubItem);
      }

      // Otherwise not an array nor object we can use
      return [];
    }

    return (menu as MenuType[]).map((item) => {
      // Verifica se é um item principal do menu (id null e tem subitens)
      let isToday = false;
      if (!isSubItem && item.id === null && item.items && item.items.length > 0) {
        // Extrai a data do texto no formato "Qua.-15-10(10)"
        const dateMatch = item.text.match(/(\d{2})-(\d{2})/);
        if (dateMatch) {
          const day = parseInt(dateMatch[1]);
          const month = parseInt(dateMatch[2]);
          const year = today.getFullYear();
          const itemDate = new Date(year, month - 1, day);
          itemDate.setHours(0, 0, 0, 0);
          isToday = itemDate.getTime() === today.getTime();
        }
      }
      
      return {
        render: () => (
          <span
            dangerouslySetInnerHTML={{ __html: item.text }}
            onClick={() => handleClick(item)}
            style={isToday ? { 
              backgroundColor: 'rgba(255, 102, 51, 0.9)', 
              padding: '4px 8px',
              borderRadius: '4px',
              paddingTop:'10px',
              height: '44px',
              lineHeight: '20px',
              color: '#fff',
              fontWeight: 'bold',
              cursor: 'pointer',
              display: 'inline-block'
            } : undefined}
          />
        ),
        items: item.items ? transformMenuTypeToTelerikFormat(handleClick, item.items, true) : [],
      };
    });
  };