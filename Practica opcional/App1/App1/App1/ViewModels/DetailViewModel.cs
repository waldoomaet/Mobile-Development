using App1.Models;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.ViewModels
{
    class DetailViewModel : BaseViewModel, INavigatedAware
    {
        public MusicViewItem MusicViewItem { get; set; }
        public string Lorem { get; set; }
        public DetailViewModel(INavigationService navigationService): base(navigationService) { }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            MusicViewItem = new MusicViewItem(parameters);
            Lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam finibus ultricies massa sed vehicula. Proin ac sollicitudin nisl. Aenean id velit et dolor vestibulum vulputate vel sit amet nisl. Etiam id felis odio. Aliquam erat volutpat. Donec sollicitudin, lorem elementum elementum ornare, mi elit tempus eros, non laoreet est sem vitae urna. Vestibulum et velit et velit placerat gravida. Nulla feugiat, neque eu imperdiet suscipit, augue dolor egestas ante, eu hendrerit est erat at nibh. Donec dignissim tristique neque ut sodales. Cras porta massa in ante hendrerit varius. Quisque mi sem, aliquam nec nibh eget, sollicitudin laoreet ex. Nam vehicula dui quam, a tristique nulla aliquet fringilla. Donec vel aliquet est. Integer pharetra ante id dolor consectetur, ac commodo erat aliquam.In sit amet nisl dolor.Vivamus vulputate ex nec odio iaculis, et mattis lorem accumsan.Nulla leo nisi, pulvinar non ullamcorper ac, laoreet at ipsum. Pellentesque ac arcu ante. Fusce dignissim nunc a ipsum porta cursus et at quam. Curabitur est mauris, finibus a urna eu, dictum pellentesque metus. In eu ipsum felis. Nullam mollis fermentum dui id semper. Suspendisse vel congue arcu. Praesent magna purus, pellentesque sed iaculis ultricies, porta vel erat. Curabitur eu finibus turpis, quis molestie libero. Sed rhoncus tortor sed elementum malesuada. Fusce massa nulla, sagittis quis mattis sit amet, accumsan et ex.Suspendisse ultricies efficitur neque, eget porta est. Nunc molestie in velit a vestibulum.Sed magna libero, vestibulum sit amet massa id, volutpat consequat est.Vivamus sed pharetra mauris, quis tempus sapien. Mauris urna erat, ornare euismod suscipit ac, tincidunt sed risus. Morbi eget magna risus. Duis vitae sem sem. Vivamus hendrerit sapien in massa iaculis, at cursus augue auctor.Integer consectetur lorem sed finibus posuere. Aliquam in elit vitae leo luctus congue et id ante. Donec ut interdum turpis. Nunc sit amet rutrum nisl.Duis pretium ac dui a pellentesque. Etiam at elementum tortor, scelerisque iaculis risus.";
        }
    }
}
