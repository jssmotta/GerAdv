// GUTAtividadesMatrizGridContainer.test.tsx
import React from 'react';
import { render, screen } from '@testing-library/react';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import GUTAtividadesMatrizGridContainer from '@/app/GerAdv_TS/GUTAtividadesMatriz/Components/GUTAtividadesMatrizGridContainer';
describe('GUTAtividadesMatrizGridContainer', () => {
  it('renders the grid component output', () => {
    // Mock grid with a render method
    const mockGrid: IGridComponent = {
      render: () => <div data-testid='mock-grid'>Mock Grid Content</div>
    };
    render(<GUTAtividadesMatrizGridContainer grid={mockGrid} />);
    // Assert the mock grid content is rendered
    expect(screen.getByTestId('mock-grid')).toHaveTextContent('Mock Grid Content');
  });
});