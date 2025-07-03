import React from 'react';
import { render } from '@testing-library/react';
import GUTPeriodicidadeIncContainer from '@/app/GerAdv_TS/GUTPeriodicidade/Components/GUTPeriodicidadeIncContainer';
// GUTPeriodicidadeIncContainer.test.tsx
// Mock do GUTPeriodicidadeInc
jest.mock('@/app/GerAdv_TS/GUTPeriodicidade/Crud/Inc/GUTPeriodicidade', () => (props: any) => (
<div data-testid='gutperiodicidade-inc-mock' {...props} />
));
describe('GUTPeriodicidadeIncContainer', () => {
  it('deve renderizar GUTPeriodicidadeInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <GUTPeriodicidadeIncContainer id={id} navigator={mockNavigator} />
  );
  const gutperiodicidadeInc = getByTestId('gutperiodicidade-inc-mock');
  expect(gutperiodicidadeInc).toBeInTheDocument();
  expect(gutperiodicidadeInc.getAttribute('id')).toBe(id.toString());

});
});